using System.Text.Json.Nodes;
using API.Belvo.Services;
using Microsoft.AspNetCore.Mvc;
using Workcube.Libraries;

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
                var lstTransacciones = await _transaccionesService.List();

                objReturn.Result = new
                {
                    transacciones = lstTransacciones,
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

            return Ok(objReturn.build());
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
            catch (AppException appEx)
            {
                objReturn.Exception(appEx);
            }
            catch (Exception ex)
            {
                objReturn.Exception(ExceptionMessage.RawException(ex));
            }

            return Ok(objReturn.build());
        }

        [HttpPost("Store")]
        public async Task<ActionResult<dynamic>> Store(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();
            try
            {
                objReturn.Result = await _transaccionesService.Create(Globals.JsonData(data));
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

            return Ok(objReturn.build());
        }

        [HttpPost("Details")]
        public async Task<ActionResult<dynamic>> Details(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();
            try
            {
                string id = Globals.ParseGuid(Globals.JsonData(data).idTransaccion);
                string fields = "ComercianteNombre,CreadoFecha,IdCuenta,IdCuentaProductoBancario,IdLink,IdTransaccion,IdTransaccionBelvo,MonedaCodigo,RecoleccionFecha," +
                                "TarjetaCreditoFacturaEstatus,TarjetaCreditoFacturaMonto,TarjetaCreditoFacturaNombre,TarjetaCreditoRecoleccionFecha,TarjetaCreditoTotalFacturaAnterior," +
                                "TransaccionCategoria,TransaccionContableFecha,TransaccionDescripcion,TransaccionEstatus,TransaccionIdentificacionInterna,TransaccionMonto," +
                                "TransaccionObservaciones,TransaccionReferencia,TransaccionSaldo,TransaccionSubCategoria,TransaccionTipo,TransaccionValorFecha";

                var objRaw = await _transaccionesService.FindSelectorById(id, fields);
                var objModel = new
                {
                    ComercianteNombre                   = objRaw.ComercianteNombre,
                    CreadoFecha                         = objRaw.CreadoFecha,
                    IdCuenta                            = objRaw.IdCuenta,
                    IdCuentaProductoBancario            = objRaw.IdCuentaProductoBancario,
                    IdLink                              = objRaw.IdLink,
                    IdTransaccion                       = objRaw.IdTransaccion,
                    IdTransaccionBelvo                  = objRaw.IdTransaccionBelvo,
                    MonedaCodigo                        = objRaw.MonedaCodigo,
                    RecoleccionFecha                    = objRaw.RecoleccionFecha,
                    TarjetaCreditoFacturaEstatus        = objRaw.TarjetaCreditoFacturaEstatus,
                    TarjetaCreditoFacturaMonto          = objRaw.TarjetaCreditoFacturaMonto,
                    TarjetaCreditoFacturaNombre         = objRaw.TarjetaCreditoFacturaNombre,
                    TarjetaCreditoRecoleccionFecha      = objRaw.TarjetaCreditoRecoleccionFecha,
                    TarjetaCreditoTotalFacturaAnterior  = objRaw.TarjetaCreditoTotalFacturaAnterior,
                    TransaccionCategoria                = objRaw.TransaccionCategoria,
                    TransaccionContableFecha            = objRaw.TransaccionContableFecha,
                    TransaccionDescripcion              = objRaw.TransaccionDescripcion,
                    TransaccionEstatus                  = objRaw.TransaccionEstatus,
                    TransaccionIdentificacionInterna    = objRaw.TransaccionIdentificacionInterna,
                    TransaccionMonto                    = objRaw.TransaccionMonto,
                    TransaccionObservaciones            = objRaw.TransaccionObservaciones,
                    TransaccionReferencia               = objRaw.TransaccionReferencia,
                    TransaccionSaldo                    = objRaw.TransaccionSaldo,
                    TransaccionSubCategoria             = objRaw.TransaccionSubCategoria,
                    TransaccionTipo                     = objRaw.TransaccionTipo,
                    TransaccionValorFecha               = objRaw.TransaccionValorFecha,
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

            return Ok(objReturn.build());
        }

        [HttpPost("Update")]
        public async Task<ActionResult<dynamic>> Update(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();
            try
            {
                objReturn.Result = await _transaccionesService.Update(Globals.JsonData(data), User);
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

            return Ok(objReturn.build());
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<dynamic>> Delete(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();
            try
            {
                objReturn.Result = await _transaccionesService.Delete(Globals.JsonData(data), User);
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

            return Ok(objReturn.build());
        }
    }
}