﻿using API.Belvo.Libraries;
using API.Belvo.ViewModels;
using API.Belvo.ViewModels.Generic;
using API.Belvo.ViewModels.Requests;
using Newtonsoft.Json;
using Workcube.Libraries;

namespace API.Belvo.Services
{
    public class BelvoService
    {
        public BelvoService() {}

        // A
        #region ACCOUNTS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todas las "Cuentas"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas las "Cuentas" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<List<CuentaListResult>> AccountsList()
        {
            WebManagerResultView result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/accounts", GlobalVariables.lstHeaders);

            if (!result.isSuccessful)
            {
                var lstMessage = JsonConvert.DeserializeObject<List<dynamic>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", Globals.ToString(lstMessage[0].code), Globals.ToString(lstMessage[1].message)));
            }

            BelvoCuentaViewModel objAccountData = JsonConvert.DeserializeObject<BelvoCuentaViewModel>(result.content);

            return objAccountData.results;
        }

        /*
        |--------------------------------------------------------------------------
        | [POST] Recupera las cuentas de un "Link"
        |--------------------------------------------------------------------------
        |
        | Se recupera las "Cuentas" de un "Link" existente.
        |
        */
        public static async Task<CuentaListResult> AccountsRetrieveForLink(ReqStoreAccount objBodyParams)
        {
            WebManagerResultView result = await WebServiceManager.Post(GlobalVariables.belvoApiUrl + "api/accounts", GlobalVariables.lstHeaders, objBodyParams);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            CuentaListResult objAccountData = JsonConvert.DeserializeObject<CuentaListResult>(result.content);

            return objAccountData;
        }

        /*
        |--------------------------------------------------------------------------
        | [PATCH] Completa una solicitud de "Cuentas"
        |--------------------------------------------------------------------------
        |
        | Se utiliza para reanudar una sesión de recuperación de "Cuentas" que se
        | detuvo porque la institución requería un token MFA.
        |
        */
        public static async Task<CuentaListResult> AccountsCompleteRequest(ReqCompleteRequestAccounts objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(GlobalVariables.belvoApiUrl + "api/accounts", GlobalVariables.lstHeaders, objBodyParams);

                if (!result.isSuccessful) { throw new ArgumentException($"No se ha podido completar la operación para reanudar una sesión de recuperación para la cuenta. Código de Estado: {result.statusCode}"); }

                CuentaListResult objAccountData = JsonConvert.DeserializeObject<CuentaListResult>(result.content);

                return objAccountData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de una "Cuenta"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de una "Cuenta" específica.
        |
        */
        public static async Task<CuentaListResult> AccountsDetails(string Id)
        {
            WebManagerResultView result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/accounts/" + Id, GlobalVariables.lstHeaders);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            CuentaListResult objAccountData = JsonConvert.DeserializeObject<CuentaListResult>(result.content);

            return objAccountData;
        }

        /*
        |--------------------------------------------------------------------------
        | [DELETE] Elimina una "Cuenta"
        |--------------------------------------------------------------------------
        |
        | Elimina una "Cuenta" específica y todas las transacciones asociadas, así
        | como propietarios, de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> AccountsDelete(string Id)
        {
            try
            {
                var result = await WebServiceManager.Delete(GlobalVariables.belvoApiUrl + "api/accounts/" + Id, GlobalVariables.lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion

        // I
        #region INSTITUTIONS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todas las "Instituciones"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas las "Instituciones" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<List<InstitucionListResult>> InstitutionsList()
        {
            WebManagerResultView result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/institutions", GlobalVariables.lstHeaders);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            BelvoInstitucionViewModel objInstitutionData = JsonConvert.DeserializeObject<BelvoInstitucionViewModel>(result.content);

            return objInstitutionData.results;
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de una "Institución"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de una "Institución" específica.
        |
        */
        public static async Task<InstitucionListResult> InstitutionsDetails(string Id)
        {
            WebManagerResultView result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/institutions/" + Id, GlobalVariables.lstHeaders);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            InstitucionListResult objInstitutionData = JsonConvert.DeserializeObject<InstitucionListResult>(result.content);

            return objInstitutionData;
        }
        #endregion

        // L
        #region LINKS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todos las "Links"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas los "Links" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<List<LinkListResult>> LinksList()
        {
            WebManagerResultView result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/links", GlobalVariables.lstHeaders);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            BelvoLinkViewModel objLinkData = JsonConvert.DeserializeObject<BelvoLinkViewModel>(result.content);

            return objLinkData.results;
        }

        /*
        |--------------------------------------------------------------------------
        | [POST] Registra un nuevo "Link"
        |--------------------------------------------------------------------------
        |
        | Se registra un nuevo "Link" con nuestra cuenta de Belvo.
        |
        */
        public static async Task<LinkListResult> LinksStore(ReqStoreLink objBodyParams)
        {
            WebManagerResultView result = await WebServiceManager.Post(GlobalVariables.belvoApiUrl + "api/links", GlobalVariables.lstHeaders, objBodyParams);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            LinkListResult objLinkData = JsonConvert.DeserializeObject<LinkListResult>(result.content);

            return objLinkData;
        }

       /*
       |--------------------------------------------------------------------------
       | [PATCH] Completa una solicitud de "Links"
       |--------------------------------------------------------------------------
       |
       | Se utiliza para reanudar una sesión de registro de "Links" que se
       | detuvo porque la institución requería un token MFA.
       |
       */
        public static async Task<LinkListResult> LinksCompleteRequest(ReqCompleteRequestLinks objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(GlobalVariables.belvoApiUrl + "api/links", GlobalVariables.lstHeaders, objBodyParams);

                if (!result.isSuccessful) { throw new ArgumentException($"No se ha podido completar la operación de reanudación de sesión para el link. Código de Estado: {result.statusCode}"); }

                LinkListResult objLinkData = JsonConvert.DeserializeObject<LinkListResult>(result.content);

                return objLinkData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de un "Link"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de un "Link" específico.
        |
        */
        public static async Task<dynamic> LinksDetails(string Id)
        {
            try
            {
                var result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/links/" + Id, GlobalVariables.lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [PATCH] Cambia el modo de acceso de un "Link"
        |--------------------------------------------------------------------------
        |
        | Cambia el modo de acceso de un "Link" de único (single) a recurrente
        | (recurrent) o de recurrente a único.
        |
        | Nota: Cuando se cambia un "Link" de único a recurrente, sólo se
        | actualizarán al día siguiente en el intervalo programado.
        |
        */
        public static async Task<dynamic> LinksChangeAccessMode(string Id, dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(GlobalVariables.belvoApiUrl + "api/links/" + Id, GlobalVariables.lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [PUT] Cambia el modo de acceso de un "Link"
        |--------------------------------------------------------------------------
        |
        | Cambia el modo de acceso de un "Link" de único (single) a recurrente
        | (recurrent) o de recurrente a único.
        |
        | Nota: Cuando se cambia un "Link" de único a recurrente, sólo se
        | actualizarán al día siguiente en el intervalo programado.
        |
        */
        public static async Task<dynamic> LinksUpdateCredentials(string Id, dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Put(GlobalVariables.belvoApiUrl + "api/links/" + Id, GlobalVariables.lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [DELETE] Elimina un "Link"
        |--------------------------------------------------------------------------
        |
        | Elimina un "Link" específico y todas las cuentas, transacciones asociadas, así
        | como propietarios, de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> LinksDelete(string Id)
        {
            try
            {
                var result = await WebServiceManager.Delete(GlobalVariables.belvoApiUrl + "api/links/" + Id, GlobalVariables.lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion

        // T
        #region TRANSACTIONS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todas las "Transacciones"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas las "Transacciones" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<List<TransaccionListResult>> TransactionsList(ReqListTransaction objQueryParams)
        {
            WebManagerResultView result = await WebServiceManager.Post(GlobalVariables.belvoApiUrl + "api/transactions", GlobalVariables.lstHeaders, objQueryParams);

            if (!result.isSuccessful)
            {
                List<WebManagerErrorView> lstMessage = JsonConvert.DeserializeObject<List<WebManagerErrorView>>(result.content);
                throw new ArgumentException(String.Format("Código de Estado: {0} - Mensaje: {1}", lstMessage[0].code, lstMessage[1].message));
            }

            BelvoTransaccionViewModel objTransactionData = JsonConvert.DeserializeObject<BelvoTransaccionViewModel>(result.content);

            return objTransactionData.results;
        }

        /*
        |--------------------------------------------------------------------------
        | [POST] Recupera las transacciones de un "Link"
        |--------------------------------------------------------------------------
        |
        | Se recupera las "Transacciones" de una o más "Cuentas" desde un "Link" 
        | existente.
        |
        */
        public static async Task<TransaccionListResult> TransactionsRetrieveForLink(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(GlobalVariables.belvoApiUrl + "api/transactions", GlobalVariables.lstHeaders, objBodyParams);

                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener las transacciones de la cuenta para su guardado."); }

                TransaccionListResult transactionData = JsonConvert.DeserializeObject<TransaccionListResult>(result.content);

                return transactionData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

       /*
       |--------------------------------------------------------------------------
       | [PATCH] Completa una solicitud de "Transacciones"
       |--------------------------------------------------------------------------
       |
       | Se utiliza para reanudar una sesión de registro de "Transacciones" que se
       | detuvo porque la institución requería un token MFA.
       |
       */
        public static async Task<dynamic> TransactionsCompleteRequest(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(GlobalVariables.belvoApiUrl + "api/transactions", GlobalVariables.lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de una "Transaccion"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de una "Transaccion" específica.
        |
        */
        public static async Task<dynamic> TransactionsDetails(string Id)
        {
            try
            {
                var result = await WebServiceManager.Get(GlobalVariables.belvoApiUrl + "api/transactions/" + Id, GlobalVariables.lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [DELETE] Elimina una "Transaccion"
        |--------------------------------------------------------------------------
        |
        | Elimina una "Transaccion" específica de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> TransactionsDelete(string Id)
        {
            try
            {
                var result = await WebServiceManager.Delete(GlobalVariables.belvoApiUrl + "api/transactions/" + Id, GlobalVariables.lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion
    }
}