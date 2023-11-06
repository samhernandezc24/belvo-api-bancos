using API.Belvo.Services;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Workcube.Libraries;
using API.Belvo.Models;

namespace API.Belvo.Controllers
{
    [ApiController]
    [Route("api/Transacciones")]
    public class TransaccionesController : ControllerBase
    {
        private readonly TransaccionesService _transaccionesService;

        public TransaccionesController(TransaccionesService transaccionesService)
        {
            _transaccionesService = transaccionesService;
        }

        [HttpPost("Index")]
        public async Task<ActionResult<dynamic>> Index()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var lstUsuarios = await _transaccionesService.List();

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
                objReturn.Result = await _transaccionesService.DataSource(Globals.JsonData(data));

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
                objReturn.Result = await _transaccionesService.Create(Globals.JsonData(data));

                objReturn.Title = "Nueva transacción";
                objReturn.Message = "La nueva transacción se ha creado exitosamente.";
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
                string id       = Globals.ParseGuid(Globals.JsonData(data).idTransaccion);
                string fields   = "AccountingFecha,Categoria,CollectedFecha,ComercianteNombre,Descripcion,IdCuenta,IdCuentaProductoBancario,IdentificacionInterna,IdExterno,IdTransaccion,MonedaCodigo,Monto,Observaciones,Referencia," +
                                  "Saldo,SubCategoria,TarjetaCreditoCollectedFecha,TarjetaCreditoCuentaNombre,TarjetaCreditoTotalCuentaAnterior,Tipo,TransaccionEstatusName,ValueFecha";

                var objRaw = await _transaccionesService.FindSelectorById(id, fields);
                var objModel = new
                {
                    AccountingFecha                     = objRaw.AccountingFecha,                    
                    Categoria                           = objRaw.Categoria,
                    CollectedFecha                      = objRaw.CollectedFecha,
                    ComercianteNombre                   = objRaw.ComercianteNombre,
                    Descripcion                         = objRaw.Descripcion,
                    IdCuenta                            = objRaw.IdCuenta,
                    IdCuentaProductoBancario            = objRaw.IdCuentaProductoBancario,
                    IdentificacionInterna               = objRaw.IdentificacionInterna,
                    IdExterno                           = objRaw.IdExterno,
                    IdTransaccion                       = objRaw.IdTransaccion,
                    MonedaCodigo                        = objRaw.MonedaCodigo,
                    Monto                               = objRaw.Monto,
                    Observaciones                       = objRaw.Observaciones,
                    Referencia                          = objRaw.Referencia,
                    Saldo                               = objRaw.Saldo,
                    SubCategoria                        = objRaw.SubCategoria,
                    TarjetaCreditoCollectedFecha        = objRaw.TarjetaCreditoCollectedFecha,
                    TarjetaCreditoCuentaNombre          = objRaw.TarjetaCreditoCuentaNombre,
                    TarjetaCreditoTotalCuentaAnterior   = objRaw.TarjetaCreditoTotalCuentaAnterior,
                    Tipo                                = objRaw.Tipo,
                    TransaccionEstatusName              = objRaw.TransaccionEstatusName,
                    ValueFecha                          = objRaw.ValueFecha,
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
                objReturn.Result = await _transaccionesService.Update(Globals.JsonData(data), User);

                objReturn.Title = "Actualizado";
                objReturn.Message = "La transacción se ha actualizado exitosamente.";
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
                objReturn.Result = await _transaccionesService.Delete(Globals.JsonData(data), User);

                objReturn.Title = "Eliminado";
                objReturn.Message = "La transacción se ha eliminado exitosamente.";
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
