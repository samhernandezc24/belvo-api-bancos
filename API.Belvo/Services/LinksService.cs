using System.Linq.Expressions;
using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            using var objTransaction = _context.Database.BeginTransaction();
            try
            {
                Link objModel = new Link
                {
                    IdLink                      = Guid.NewGuid().ToString(),
                    ModoAcceso                  = data.access_mode,
                    CreadoFecha                 = data.created_at,
                    CreadoPor                   = data.created_by,
                    AlmacenamientoCredenciales  = data.credentials_storage,
                    IdExterno                   = data.external_id,
                    BuscarRecursos              = JsonConvert.SerializeObject(data.fetch_resources),
                    IdLinkBelvo                 = data.id,
                    Institucion                 = data.institution,
                    IdUsuarioInstitucion        = data.institution_user_id,
                    UltimoAccesoFecha           = data.last_accessed_at,
                    TasaActualizacion           = data.refresh_rate,
                    LinkVencimiento             = data.stale_in,
                    LinkEstatus                 = data.status,
                };

                _context.Links.Add(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al crear el objeto Link: " + ex.Message, ex);
            }
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
        
        public async Task<dynamic> DataSource(dynamic data)
        {
            // Obtener la lista de elementos a través de la expresión de origen de datos.
            IQueryable<LinkViewModel> lstItems                      = DataSourceExpression(data);
            // Construir el objeto de origen de datos usando el constructor adecuado.
            DataSourceBuilder<LinkViewModel> objDataTableBuilder    = new DataSourceBuilder<LinkViewModel>(data, lstItems);

            // Obtener el resultado del objeto de origen de datos.
            var objDataTableResult          = await objDataTableBuilder.build();
            List<LinkViewModel> lstOriginal = objDataTableResult.rows;

            // Proyectar las propiedades deseadas en una nueva lista de objetos.
            var lstRows = lstOriginal.Select(x => new 
            {
                IdLink                      = x.IdLink,
                AlmacenamientoCredenciales  = x.AlmacenamientoCredenciales,
                BuscarRecursos              = x.BuscarRecursos,
                CreadoFecha                 = x.CreadoFecha,
                CreadoPor                   = x.CreadoPor,
                IdExterno                   = x.IdExterno,
                IdUsuarioInstitucion        = x.IdUsuarioInstitucion,
                Institucion                 = x.Institucion,
                LinkEstatus                 = x.LinkEstatus,
                LinkVencimiento             = x.LinkVencimiento,
                ModoAcceso                  = x.ModoAcceso,
                TasaActualizacion           = x.TasaActualizacion,
                UltimoAccesoFecha           = x.UltimoAccesoFecha,
            }).ToList();

            // Construir el objeto de devolución con la lista proyectada y otras propiedades.
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
            try
            {
                string id       = Globals.ParseGuid(data.idLink);
                Link objModel   = await Find(id) ?? throw new ArgumentException($"No se encontró el link con el Id: {id}");

                if (objModel.Deleted) { throw new InvalidOperationException($"El objeto Link con el Id {id} ya ha sido marcado como eliminado."); }

                objModel.Deleted = true;
                objModel.SetUpdated(Globals.GetUser(user));

                _context.Links.Update(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al eliminar el objeto Link: " + ex.Message, ex);
            }
        }

        public async Task<Link> Find(string id)
        {
            var link = await _context.Links.FindAsync(id);
            return link ?? throw new ArgumentException($"No se encontró el link con el Id: {id}");
        }

        public async Task<Link> FindSelectorById(string id, string fields)
        {
            var link = await _context.Links.Where(x => x.IdLink == id).Select(Globals.BuildSelector<Link, Link>(fields)).FirstOrDefaultAsync();
            return link ?? throw new ArgumentException($"No se encontró el link con el Id: {id} o el campo especificado '{fields}' no es válido en la búsqueda.");
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Links.Where(x => !x.Deleted).Select(x => new { x.IdExterno, x.Institucion, x.LinkEstatus } ).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            var link = await _context.Links.Where(x => !x.Deleted && x.IdLink == id).Select(Globals.BuildSelector<Link, Link>(fields)).ToListAsync<dynamic>();
            return link ?? throw new ArgumentException($"No se encontró el link con el Id: {id} o el campo especificado '{fields}' no es válido en la búsqueda.");
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();            
            try
            {
                string id       = Globals.ParseGuid(data.idLink);
                Link objModel   = await Find(id) ?? throw new ArgumentException($"No se encontró el link con el Id: {id}");

                objModel.ModoAcceso                  = data.access_mode;
                objModel.CreadoFecha                 = data.created_at;
                objModel.CreadoPor                   = data.created_by;
                objModel.AlmacenamientoCredenciales  = data.credentials_storage;
                objModel.IdExterno                   = data.external_id;
                objModel.BuscarRecursos              = JsonConvert.SerializeObject(data.fetch_resources);
                objModel.IdLinkBelvo                 = data.id;
                objModel.Institucion                 = data.institution;
                objModel.IdUsuarioInstitucion        = data.institution_user_id;
                objModel.UltimoAccesoFecha           = data.last_accessed_at;
                objModel.TasaActualizacion           = data.refresh_rate;
                objModel.LinkVencimiento             = data.stale_in;
                objModel.LinkEstatus                 = data.status;

                _context.Links.Update(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al actualizar el objeto Link: " + ex.Message, ex);
            }
        }
    }
}