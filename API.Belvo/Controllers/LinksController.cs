using System.Text.Json.Nodes;
using API.Belvo.Services;
using API.Belvo.ViewModels;
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
                var lstUsuarios = await _linksService.List();

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
                objReturn.Result = await _linksService.DataSource(Globals.JsonData(data));

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
                objReturn.Result = await _linksService.Create(Globals.JsonData(data));

                objReturn.Title = "Nuevo link";
                objReturn.Message = "El nuevo link se ha creado exitosamente.";
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
                string id       = Globals.ParseGuid(Globals.JsonData(data).idLink);
                string fields   = "AlmacenamientoCredenciales,BuscarRecursos,CreadoPor,IdExterno,IdInstitucionUser,IdLink,Institucion,IsFetchHistorical,LastAccessedFecha,LinkCreatedFecha,LinkEstatusName,ModoAcceso,TasaActualizacion,Vencimiento";

                var objRaw = await _linksService.FindSelectorById(id, fields);
                var objModel = new
                {
                    //AlmacenamientoCredenciales  = objRaw.AlmacenamientoCredenciales,
                    //BuscarRecursos              = objRaw.BuscarRecursos,
                    //CreadoPor                   = objRaw.CreadoPor,
                    //IdExterno                   = objRaw.IdExterno,
                    //IdInstitucionUser           = objRaw.IdInstitucionUser,
                    //IdLink                      = objRaw.IdLink,
                    //Institucion                 = objRaw.Institucion,
                    //IsFetchHistorical           = objRaw.IsFetchHistorical,
                    //LastAccessedFecha           = objRaw.LastAccessedFecha,
                    //LinkCreatedFecha            = objRaw.LinkCreatedFecha,
                    //LinkEstatusName             = objRaw.LinkEstatusName,
                    //ModoAcceso                  = objRaw.ModoAcceso,
                    //TasaActualizacion           = objRaw.TasaActualizacion,
                    //Vencimiento                 = objRaw.Vencimiento,
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
                objReturn.Result = await _linksService.Update(Globals.JsonData(data), User);

                objReturn.Title = "Actualizado";
                objReturn.Message = "El link se ha actualizado exitosamente.";
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
                objReturn.Result = await _linksService.Delete(Globals.JsonData(data), User);

                objReturn.Title = "Eliminado";
                objReturn.Message = "El link se ha eliminado exitosamente.";
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
