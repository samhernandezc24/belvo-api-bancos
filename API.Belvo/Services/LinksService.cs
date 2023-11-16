using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Security.Claims;
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

        public async Task Create(LinkListResult data)
        {
            // using var objTransaction = _context.Database.BeginTransaction();

            var objUser = new ModelGetUser { Id = data.id, Nombre = "Admin Manager" };

            Link objModel = new Link
            {
                IdLink                      = data.id,
                ModoAcceso                  = data.access_mode,
                CreadoFecha                 = data.created_at,
                CreadoPor                   = data.created_by,
                AlmacenamientoCredenciales  = data.credentials_storage,
                BuscarRecursos              = JsonConvert.SerializeObject(data.fetch_resources),
                Institucion                 = data.institution,
                IdUsuarioInstitucion        = data.institution_user_id,
                UltimoAccesoFecha           = data.last_accessed_at,
                TasaActualizacion           = data.refresh_rate,
                LinkVencimiento             = data.stale_in,
                LinkEstatusName             = data.status,
            };

            objModel.SetCreated(objUser);

            _context.Links.Add(objModel);
            await _context.SaveChangesAsync();
            // objTransaction.Commit();
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
                    CreadoFecha                 = x.CreadoFecha,
                    CreadoPor                   = x.CreadoPor,
                    IdUsuarioInstitucion        = x.IdUsuarioInstitucion,
                    Institucion                 = x.Institucion,
                    LinkEstatusName             = x.LinkEstatusName,
                    LinkVencimiento             = x.LinkVencimiento,
                    ModoAcceso                  = x.ModoAcceso,
                    TasaActualizacion           = x.TasaActualizacion,
                    UltimoAccesoFecha           = x.UltimoAccesoFecha,
                });
            });

            var objReturn = new
            {
                rows    = lstRows,
                count   = objDataTableResult.count,
                length  = objDataTableResult.length,
                pages   = objDataTableResult.pages,
                page    = objDataTableResult.page,
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
            DateTime? dateFrom  = SourceExpression<Link>.Date((string)data.dateFrom);
            DateTime? dateTo    = SourceExpression<Link>.Date((string)data.dateTo);

            var dictDates = new Dictionary<string, DateExpression<Link>>()
            {
                { "CreatedFecha", new DateExpression<Link>{ dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Link>{ dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } },
            };

            Expression<Func<Link, bool>> ExpFullWhere = SourceExpression<Link>.GetExpression(data, dictFilters, dictDates, dictMultipleFilters);

            // ORDER BY
            var orderColumn     = Globals.ToString(data.sort.column);
            var orderDirection  = Globals.ToString(data.sort.direction);

            Expression<Func<Link, object>> sortExpression;

            switch (orderColumn)
            {
                case "createdUserName"  : sortExpression = (x => x.CreatedUserName);    break;
                case "createdFecha"     : sortExpression = (x => x.CreatedFecha);       break;
                case "updatedUserName"  : sortExpression = (x => x.UpdatedUserName);    break;
                case "updatedFecha"     : sortExpression = (x => x.UpdatedFecha);       break;
                default                 : sortExpression = (x => x.CreatedFecha);       break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdLink");
            columns.Add("IdCreatedUser");
            columns.Add("CreatedUserName");
            columns.Add("IdUpdatedUser");
            columns.Add("UpdatedUserName");

            string strColumns = Globals.GetStringColumns(columns);

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
            using var objTransaction = _context.Database.BeginTransaction();

            string id = Globals.ParseGuid(data.idLink);
            Link objModel = await Find(id) ?? throw new ArgumentException(String.Format("No se encontró el link con el Id: {0}", id));

            if (objModel.Deleted) { throw new ArgumentException(String.Format("El link con el Id {0} ya había sido eliminado previamente.", id)); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Links.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Link> Find(string id)
        {
            return await _context.Links.FindAsync(id) ?? throw new ArgumentException(String.Format("No se encontró el link con el Id: {0}", id));
        }

        public async Task<Link> FindSelectorById(string id, string fields)
        {
            var link = await _context.Links.Where(x => x.IdLink == id).Select(Globals.BuildSelector<Link, Link>(fields)).FirstOrDefaultAsync();
            return link ?? throw new ArgumentException(String.Format("No se encontró el link con el Id: {0} o el campo especificado '{1}' no es válido en la búsqueda.", id, fields));
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Links.Where(x => !x.Deleted).Select(x => new { x.IdLink, x.Institucion, x.LinkEstatusName } ).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            var link = await _context.Links.Where(x => !x.Deleted && x.IdLink == id).Select(Globals.BuildSelector<Link, Link>(fields)).ToListAsync<dynamic>();
            return link ?? throw new ArgumentException(String.Format("No se encontró el link con el Id: {0} o el campo especificado '{1}' no es válido en la búsqueda.", id, fields));
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();
            
            string id       = Globals.ParseGuid(data.idLink);
            Link objModel   = await Find(id) ?? throw new ArgumentException(String.Format("No se encontró el link con el Id: {0}", id));

            objModel.ModoAcceso                  = data.access_mode;
            objModel.CreadoFecha                 = data.created_at;
            objModel.CreadoPor                   = data.created_by;
            objModel.AlmacenamientoCredenciales  = data.credentials_storage;
            objModel.BuscarRecursos              = JsonConvert.SerializeObject(data.fetch_resources);
            objModel.Institucion                 = data.institution;
            objModel.IdUsuarioInstitucion        = data.institution_user_id;
            objModel.UltimoAccesoFecha           = data.last_accessed_at;
            objModel.TasaActualizacion           = data.refresh_rate;
            objModel.LinkVencimiento             = data.stale_in;
            objModel.LinkEstatusName             = data.status;

            _context.Links.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}