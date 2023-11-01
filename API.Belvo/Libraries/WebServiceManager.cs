using RestSharp;

namespace API.Belvo.Libraries
{
    public class WebServiceManager
    {
        public static async Task<dynamic> Get(string url, IEnumerable<dynamic> headers, List<dynamic> parameters = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Get);

                foreach (var itemHeader in headers)
                {
                    request.AddHeader((string)itemHeader.name, (string)itemHeader.value);
                }

                if (parameters != null)
                {
                    foreach (var itemParameter in parameters)
                    {
                        request.AddParameter((string)itemParameter.name, (string)itemParameter.value);
                    }
                }

                var response = await client.ExecuteAsync(request);
                var result = new
                {
                    content         =   response.Content,
                    bytes           =   response.RawBytes,
                    statusCode      =   response.StatusCode.ToString(),
                    isSuccessful    =   response.IsSuccessful,
                };

                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> Post(string url, IEnumerable<dynamic> headers, dynamic objParameter = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Post);

                foreach (var itemHeader in headers)
                {
                    request.AddHeader((string)itemHeader.name, (string)itemHeader.value);
                }

                if (objParameter != null)
                {
                    request.AddJsonBody((string)objParameter);
                }

                var response = await client.ExecuteAsync(request);
                var result = new
                {
                    content         =   response.Content,
                    bytes           =   response.RawBytes,
                    statusCode      =   response.StatusCode.ToString(),
                    isSuccessful    =   response.IsSuccessful,
                };

                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> Patch(string url, IEnumerable<dynamic> headers, dynamic objParameter = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Patch);

                foreach (var itemHeader in headers)
                {
                    request.AddHeader((string)itemHeader.name, (string)itemHeader.value);
                }

                if (objParameter != null)
                {
                    request.AddJsonBody((string)objParameter);
                }

                var response = await client.ExecuteAsync(request);
                var result = new
                {
                    content         =   response.Content,
                    bytes           =   response.RawBytes,
                    statusCode      =   response.StatusCode.ToString(),
                    isSuccessful    =   response.IsSuccessful,
                };

                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> Put(string url, IEnumerable<dynamic> headers, dynamic objParameter = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Put);

                foreach (var itemHeader in headers)
                {
                    request.AddHeader((string)itemHeader.name, (string)itemHeader.value);
                }

                if (objParameter != null)
                {
                    request.AddJsonBody((string)objParameter);
                }

                var response = await client.ExecuteAsync(request);
                var result = new
                {
                    content         =   response.Content,
                    bytes           =   response.RawBytes,
                    statusCode      =   response.StatusCode.ToString(),
                    isSuccessful    =   response.IsSuccessful,
                };

                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> Delete(string url, IEnumerable<dynamic> headers, dynamic objParameter = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Delete);

                foreach (var itemHeader in headers)
                {
                    request.AddHeader((string)itemHeader.name, (string)itemHeader.value);
                }

                if (objParameter != null)
                {
                    request.AddJsonBody((string)objParameter);
                }

                var response = await client.ExecuteAsync(request);
                var result = new
                {
                    content         =   response.Content,
                    bytes           =   response.RawBytes,
                    statusCode      =   response.StatusCode.ToString(),
                    isSuccessful    =   response.IsSuccessful,
                };

                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
    }
}
