using System.Text.Json.Nodes;
using API.Belvo.Services;
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
                var lstUsuarios = await _cuentasService.List();

                objReturn.Result = new
                {
                    usuarios = lstUsuarios,
                };

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
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
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Store")]
        public async Task<ActionResult<dynamic>> Store(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                objReturn.Result = await _cuentasService.Create(Globals.JsonData(data));

                objReturn.Title = "Nueva cuenta";
                objReturn.Message = "La nueva cuenta se ha creado exitosamente.";
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Details")]
        public async Task<ActionResult<dynamic>> Details(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                string id = Globals.ParseGuid(Globals.JsonData(data).idCuenta);
                string fields = "CuentaAgencia,CuentaCategoria,CuentaCreatedFecha,CuentaLastAccessedFecha,CuentaMonedaCodigo,CuentaNombre,CuentaNumero,CuentaSaldoTipo,CuentaTipo,IdCuenta,IdExterno,IdLink,IdProductoBancario," +
                                "InstitucionCodigo,InstitucionNombre,InstitucionTipo,SaldoActual,SaldoDisponible";

                var objRaw = await _cuentasService.FindSelectorById(id, fields);
                var objModel = new
                {
                    CuentaAgencia           = objRaw.CuentaAgencia,
                    CuentaCategoria         = objRaw.CuentaCategoria,
                    CuentaCreatedFecha      = objRaw.CuentaCreatedFecha,
                    CuentaLastAccessedFecha = objRaw.CuentaLastAccessedFecha,
                    CuentaMonedaCodigo      = objRaw.CuentaMonedaCodigo,
                    CuentaNombre            = objRaw.CuentaNombre,
                    CuentaNumero            = objRaw.CuentaNumero,
                    CuentaSaldoTipo         = objRaw.CuentaSaldoTipo,
                    CuentaTipo              = objRaw.CuentaTipo,
                    IdCuenta                = objRaw.IdCuenta,
                    IdExterno               = objRaw.IdExterno,
                    IdLink                  = objRaw.IdLink,
                    IdProductoBancario      = objRaw.IdProductoBancario,
                    InstitucionCodigo       = objRaw.InstitucionCodigo,
                    InstitucionNombre       = objRaw.InstitucionNombre,
                    InstitucionTipo         = objRaw.InstitucionTipo,
                    SaldoActual             = objRaw.SaldoActual,
                    SaldoDisponible         = objRaw.SaldoDisponible,
                };

                objReturn.Result = objModel;

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
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

                objReturn.Title = "Actualizado";
                objReturn.Message = "La cuenta se ha actualizado exitosamente.";
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
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

                objReturn.Title = "Eliminado";
                objReturn.Message = "La cuenta se ha eliminado exitosamente.";
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }
    }
}
