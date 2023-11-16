using API.Belvo.Services;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Workcube.Libraries;

namespace API.Belvo.Controllers
{
    [ApiController]
    [Route("api/Cuentas/Bancarias")]
    public class CuentasController : ControllerBase
    {
        private readonly CuentasService _cuentasService;
            
        public CuentasController(CuentasService cuentasService)
        {
            _cuentasService = cuentasService;
        }

        [HttpPost("Index")]
        public async Task<ActionResult<dynamic>> Index()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var lstInstituciones    = await BelvoService.InstitutionsList();
                var lstUsuarios         = await _cuentasService.UsuariosList();

                objReturn.Result = new
                {
                    instituciones   = lstInstituciones,
                    usuarios        = lstUsuarios,
                };

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }

        [HttpPost("DataSource")]
        public async Task<ActionResult<dynamic>> List(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                objReturn.Result = await _cuentasService.DataSource(Globals.JsonData(data));
                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<dynamic>> Create()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var lstInstituciones = await BelvoService.InstitutionsList();

                objReturn.Result = new
                {
                    instituciones = lstInstituciones,
                };

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }

        [HttpPost("Store")]
        public async Task<ActionResult<dynamic>> Store(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _cuentasService.Create(Globals.JsonData(data), null);

                objReturn.Title     = "Cuenta Creada";
                objReturn.Message   = "La nueva cuenta se ha creado exitosamente.";
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }

        [HttpPost("Details")]
        public async Task<ActionResult<dynamic>> Details(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                string id       = Globals.ParseGuid(Globals.JsonData(data).idCuenta);
                string fields   = "CreadoFecha,CuentaAgencia,CuentaCategoria,CuentaIdentificacionInterna,CuentaIdentificacionPublicaNombre,CuentaIdentificacionPublicaValor," +
                                  "CuentaNombre,CuentaNumero,CuentaTipo,CuentaTipoSaldo,IdCuenta,IdLink,IdProductoBancario,InstitucionCodigo,InstitucionNombre" +
                                  "InstitucionTipo,MonedaCodigo,RecoleccionFecha,SaldoActual,SaldoDisponible,UltimoAccesoFecha";

                var objRaw = await _cuentasService.FindSelectorById(id, fields);
                var objModel = new
                {
                    CreadoFecha                         = objRaw.CreadoFecha,                    
                    CuentaAgencia                       = objRaw.CuentaAgencia,
                    CuentaCategoria                     = objRaw.CuentaCategoria,
                    CuentaIdentificacionInterna         = objRaw.CuentaIdentificacionInterna,
                    CuentaIdentificacionPublicaNombre   = objRaw.CuentaIdentificacionPublicaNombre,
                    CuentaIdentificacionPublicaValor    = objRaw.CuentaIdentificacionPublicaValor,
                    CuentaNombre                        = objRaw.CuentaNombre,
                    CuentaNumero                        = objRaw.CuentaNumero,
                    CuentaTipo                          = objRaw.CuentaTipo,
                    CuentaTipoSaldo                     = objRaw.CuentaTipoSaldo,
                    IdCuenta                            = objRaw.IdCuenta,
                    IdLink                              = objRaw.IdLink,
                    IdProductoBancario                  = objRaw.IdProductoBancario,
                    InstitucionCodigo                   = objRaw.InstitucionCodigo,
                    InstitucionNombre                   = objRaw.InstitucionNombre,
                    InstitucionTipo                     = objRaw.InstitucionTipo,
                    MonedaCodigo                        = objRaw.MonedaCodigo,
                    RecoleccionFecha                    = objRaw.RecoleccionFecha,
                    SaldoActual                         = objRaw.SaldoActual,
                    SaldoDisponible                     = objRaw.SaldoDisponible,
                    UltimoAccesoFecha                   = objRaw.UltimoAccesoFecha,
                };

                objReturn.Result = objModel;
                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }

        [HttpPost("Update")]
        public async Task<ActionResult<dynamic>> Update(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                objReturn.Result = await _cuentasService.Update(Globals.JsonData(data), User);


                objReturn.Title     = "Cuenta Actualizada";
                objReturn.Message   = "La cuenta se ha actualizado exitosamente.";
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<dynamic>> Delete(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                objReturn.Result = await _cuentasService.Delete(Globals.JsonData(data), User);

                objReturn.Title     = "Cuenta Eliminada";
                objReturn.Message   = "La cuenta se ha eliminado exitosamente.";
            }
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return objReturn.build();
        }
    }
}