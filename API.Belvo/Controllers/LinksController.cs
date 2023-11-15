using System.Text.Json.Nodes;
using API.Belvo.Services;
using Microsoft.AspNetCore.Mvc;
using Workcube.Libraries;

namespace API.Belvo.Controllers
{
    [ApiController]
    [Route("api/Links")]
    public class LinksController : ControllerBase
    {
        private readonly LinksService _linksService;

        public LinksController(LinksService linksService) 
        {
            _linksService = linksService;
        }

        [HttpPost("Index")]
        public async Task<ActionResult<dynamic>> Index()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var lstLinks = await _linksService.List();

                objReturn.Result = new
                {
                    links = lstLinks,                     
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
                objReturn.Result = await _linksService.DataSource(Globals.JsonData(data));
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
                objReturn.Result = await _linksService.Create(Globals.JsonData(data));
                
                objReturn.Title     = "Link Creado";
                objReturn.Message   = "El nuevo link se ha generado exitosamente.";
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
                string id       = Globals.ParseGuid(Globals.JsonData(data).idLink);
                string fields   = "AlmacenamientoCredenciales,BuscarRecursos,CreadoFecha,CreadoPor,IdLink,IdUsuarioInstitucion,Institucion,LinkEstatus,LinkVencimiento,ModoAcceso,TasaActualizacion,UltimoAccesoFecha";

                var objRaw = await _linksService.FindSelectorById(id, fields);
                var objModel = new
                {
                    AlmacenamientoCredenciales  = objRaw.AlmacenamientoCredenciales,
                    BuscarRecursos              = objRaw.BuscarRecursos,
                    CreadoFecha                 = objRaw.CreadoFecha,
                    CreadoPor                   = objRaw.CreadoPor,
                    IdLink                      = objRaw.IdLink,
                    IdUsuarioInstitucion        = objRaw.IdUsuarioInstitucion,
                    Institucion                 = objRaw.Institucion,
                    LinkEstatusName             = objRaw.LinkEstatusName,
                    LinkVencimiento             = objRaw.LinkVencimiento,
                    ModoAcceso                  = objRaw.ModoAcceso,
                    TasaActualizacion           = objRaw.TasaActualizacion,
                    UltimoAccesoFecha           = objRaw.UltimoAccesoFecha,
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
                objReturn.Result = await _linksService.Update(Globals.JsonData(data), User);
                
                objReturn.Title     = "Link Actualizado";
                objReturn.Message   = "El link se ha actualizado exitosamente.";
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
                objReturn.Result = await _linksService.Delete(Globals.JsonData(data), User);
                
                objReturn.Title     = "Link Eliminado";
                objReturn.Message   = "El link se ha eliminado exitosamente.";
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