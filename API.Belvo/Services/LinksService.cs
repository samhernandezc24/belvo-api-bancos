using System.Linq.Expressions;
using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using iTextSharp.text.html.simpleparser;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using Workcube.Interfaces;
using Workcube.Libraries;
using Workcube.ViewModels;

namespace API.Belvo.Services
{
    public class LinksService : IGlobal<Link>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LinksService(Context context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;   
        }

        public Task Create(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task Create(dynamic data)
        {
            var objTransaction = _context.Database.BeginTransaction();

            Link objModel                       = new Link();
            objModel.IdLink                     = Guid.NewGuid().ToString();
            objModel.Institucion                = data.institution;
            objModel.ModoAcceso                 = data.access_mode;
            objModel.LinkEstatusName            = data.status;
            objModel.TasaActualizacion          = data.refresh_rate;
            objModel.CreadoPor                  = data.created_by;
            objModel.LastAccessedFecha          = data.last_accessed_at;
            objModel.IdExterno                  = data.external_id;
            objModel.LinkCreatedFecha           = data.created_at;
            objModel.IdInstitucionUser          = data.institution_user_id;
            objModel.AlmacenamientoCredenciales = data.credentials_storage;
            objModel.Vencimiento                = data.stale_in;
            objModel.IsFetchHistorical          = data.fetch_historical;
            objModel.BuscarRecursos             = JsonConvert.SerializeObject(data.fetch_resources);

            _context.Links.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> DataSource(dynamic data)
        {
            IQueryable<LinkViewModel> lstItems                      = DataSourceExpression(data);
            DataSourceBuilder<LinkViewModel> objDataTableBuilder    = new DataSourceBuilder<LinkViewModel>(data, lstItems);

            var objDataTableResult          = await objDataTableBuilder.build();
            List<LinkViewModel> lstOriginal = objDataTableResult.rows;
            List<dynamic> lstRows           = new List<dynamic>();

            lstOriginal.ForEach(x =>
            {
                lstRows.Add(new
                {
                    IdLink                      = x.IdLink,
                    AlmacenamientoCredenciales  = x.AlmacenamientoCredenciales,
                    BuscarRecursos              = x.BuscarRecursos,
                    CreadoPor                   = x.CreadoPor,
                    IdExterno                   = x.IdExterno,
                    IdInstitucionUser           = x.IdInstitucionUser,
                    Institucion                 = x.Institucion,
                    IsFechtHistorial            = x.IsFetchHistorical,
                    LastAccessedFecha           = x.LastAccessedFecha,
                    LinkCreatedFecha            = x.LinkCreatedFecha,
                    LinkEstatusName             = x.LinkEstatusName,
                    ModoAcceso                  = x.ModoAcceso,
                    TasaActualizacion           = x.TasaActualizacion,
                    Vencimiento                 = x.Vencimiento,
                });
            });

            var objReturn = new
            {
                rows        = lstRows,
                count       = objDataTableResult.count,
                length      = objDataTableResult.length,
                pages       = objDataTableResult.pages,
                page        = objDataTableResult.page,
            };

            return objReturn;
        }

        public IQueryable<LinkViewModel> DataSourceExpression(dynamic data)
        {
            // INCLUDES
            IQueryable<LinkViewModel> lstItems;

            // APLICAR FILTROS DINÁMICOS
            // FILTROS
            var dictFilters = new Dictionary<string, Func<string, Expression<Func<Link, bool>>>>
            {
                { "CreatedAspNetUser.Id", (strValue) => item => item.IdCreatedUser == strValue },
                { "UpdatedAspNetUser.Id", (strValue) => item => item.IdUpdatedUser == strValue },
            };

            // FILTROS MÚLTIPLES
            var dictMultipleFilters = new Dictionary<string, Func<string, Expression<Func<Link, bool>>>> { };

            // FILTROS FECHAS
            DateTime? dateFrom = SourceExpression<Link>.Date((string)data.dateFrom);
            DateTime? dateTo = SourceExpression<Link>.Date((string)data.dateTo);

            var dictDates = new Dictionary<string, DateExpression<Link>>()
            {
                { "CreatedFecha", new DateExpression<Link> { dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Link> { dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } },
            };

            Expression<Func<Link, bool>> ExpFullWhere = SourceExpression<Link>.GetExpression(data, dictFilters, dictDates, dictMultipleFilters);

            // ORDER BY
            var orderColumn     = Globals.ToString(data.sort.column);
            var orderDirection  = Globals.ToString(data.sort.direction);

            Expression<Func<Link, object>> sortExpression;
            switch (orderColumn)
            {
                case "createdUserName"      : sortExpression = (x => x.CreatedUserName);    break;
                case "createdFecha"         : sortExpression = (x => x.CreatedFecha);       break;
                case "updatedUserName"      : sortExpression = (x => x.UpdatedUserName);    break;
                case "updatedFecha"         : sortExpression = (x => x.UpdatedFecha);       break;
                default                     : sortExpression = (x => x.CreatedUserName);    break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdLink");
            columns.Add("IdCreatedUser");
            columns.Add("CreatedUserName");
            columns.Add("IdUpdatedUser");
            columns.Add("UpdatedUserName");

            string strColumns = Globals.GetStringColumns(data);

            IQueryable<Link> rows = _context.Links.AsNoTracking();

            if (orderDirection == "asc")
            {
                rows = rows.OrderBy(sortExpression);
            }
            else
            {
                rows = rows.OrderByDescending(sortExpression);
            }

            lstItems = rows
                        .Where(x => !x.Deleted)
                        .Where(ExpFullWhere)
                        .Select(Globals.BuildSelector<Link, Link>(strColumns))
                        .ProjectTo<LinkViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();
            string idLink = Globals.ParseGuid(data.idLink);
            Link objModel = await Find(idLink);

            if (objModel == null) { throw new ArgumentException("No se ha podido encontrar el link especificado."); }
            if (objModel.Deleted) { throw new ArgumentException("Este link ya había sido eliminado anteriormente.");  }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Links.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Link> Find(string id)
        {
            var link = await _context.Links.FindAsync(id);
            return link ?? throw new ArgumentException("No se encontró un link con el ID " + id);
        }

        public async Task<Link> FindSelectorById(string id, string fields)
        {
            var link = await _context.Links.Where(x => x.IdLink == id).Select(Globals.BuildSelector<Link, Link>(fields)).FirstOrDefaultAsync();
            return link ?? throw new ArgumentException("No se encontró un link con el ID " + id);
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Links.Where(x => !x.Deleted).Select(x => new { x.IdLink, x.Institucion, x.LinkEstatusName }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            return await _context.Links.Where(x => !x.Deleted && x.IdLink == id).Select(Globals.BuildSelector<Link, Link>(fields)).ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();
            string idLink = Globals.ParseGuid(data.idLink);
            Link objModel = await Find(idLink);

            if (objModel == null) { throw new ArgumentException("No se ha podido encontrar el link especificado."); }

            objModel.Institucion                = data.institution;
            objModel.ModoAcceso                 = data.access_mode;
            objModel.LinkEstatusName            = data.status;
            objModel.TasaActualizacion          = data.refresh_rate;
            objModel.CreadoPor                  = data.created_by;
            objModel.LastAccessedFecha          = data.last_accessed_at;
            objModel.IdExterno                  = data.external_id;
            objModel.LinkCreatedFecha           = data.created_at;
            objModel.IdInstitucionUser          = data.institution_user_id;
            objModel.AlmacenamientoCredenciales = data.credentials_storage;
            objModel.Vencimiento                = data.stale_in;
            objModel.IsFetchHistorical          = data.fetch_historical;
            objModel.BuscarRecursos             = JsonConvert.SerializeObject(data.fetch_resources);

            _context.Links.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
