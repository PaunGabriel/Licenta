using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpinIt.Data.Services
{
    public class APIConnector
    {
        public static IHttpContextAccessor _httpContext;
        public APIConnector(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        //private static string baseAddress = "http://localhost:60109/";
        private static string baseAddress = GetAppSettingsFromConfig("BaseUrl");

        public static string GetPublicKey(string uri)
        {
            string publicKey = string.Empty;

            using (var client = CreateClient(false))
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    byte[] key = response.Content.ReadAsByteArrayAsync().Result;
                    publicKey = Encoding.UTF8.GetString(key);
                }

                if (string.IsNullOrEmpty(publicKey))
                {
                    throw new Exception("Unable to get public key from server.");
                }
            }

            return publicKey;

        }

        public static APIResponse GetData(string uri)
        {
            using (var client = CreateClient(true))
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;
                APIResponse result = new APIResponse(response.IsSuccessStatusCode, (int)response.StatusCode);

                if (!result.IsSuccess)
                {
                    // ErrorResponse error = response.Content.ReadAsAsync<ErrorResponse>().Result;
                    var results = response.Content.ReadAsStringAsync().Result;
                    ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(results);
                    //var error = response.Content.ReadAsAsync<ErrorResponse>().Result;
                    result.ErrorData = error;
                }
                else
                {
                    result.ResponseData = response.Content.ReadAsStringAsync().Result;  // response.Content.ReadAsAsync<string>().Result;
                }

                return result;
            }
        }

        public static APIResponse GetDataWithJwt(string uri, string jwtToken)
        {
             
            using (var client = CreateClient(true,jwtToken))
            {
                HttpResponseMessage response = client.GetAsync(requestUri:uri).Result;
                APIResponse result = new APIResponse(response.IsSuccessStatusCode, (int)response.StatusCode);

                if (!result.IsSuccess)
                {
                    // ErrorResponse error = response.Content.ReadAsAsync<ErrorResponse>().Result;
                    var results = response.Content.ReadAsStringAsync().Result;
                    ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(results);
                    //var error = response.Content.ReadAsAsync<ErrorResponse>().Result;
                    result.ErrorData = error;
                }
                else
                {
                    result.ResponseData = response.Content.ReadAsStringAsync().Result;  // response.Content.ReadAsAsync<string>().Result;
                }

                return result;
            }
        }

        public static APIResponse PostData(string uri, Message data)
        {
            using (var client = CreateClient(true, data.apiKey))
            {

                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");


                HttpResponseMessage response = client.PostAsync(uri, httpContent).Result;
                APIResponse result = new APIResponse(response.IsSuccessStatusCode, (int)response.StatusCode);

                if (!result.IsSuccess)
                {
                    if (result.ResponseCode == 404)
                    {
                        ErrorResponse error = new ErrorResponse();
                        error.ExceptionMessage = "(404) URL not found.";
                        error.Message = "(404) URL not found.";
                        result.ErrorData = error;
                    }
                    else if (result.ResponseCode == 500)
                    {
                        ErrorResponse error = new ErrorResponse();
                        error.ExceptionMessage = "(500) Internal Server Error.";
                        error.Message = "(500) Internal Server Error.";
                        result.ErrorData = error;
                    }
                    else
                    { 

                        var results = response.Content.ReadAsStringAsync().Result;
                        ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(results);
                        result.ErrorData = error;
                    }
                }
                else
                {
                    result.ResponseData = response.Content.ReadAsStringAsync().Result;
                }

                return result;

                 
            }
        }
         

        public static APIResponse PutData(string uri, Message data)
        {
            using (var client = CreateClient(true, data.apiKey))
            {

                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(uri, httpContent).Result;
                APIResponse result = new APIResponse(response.IsSuccessStatusCode, (int)response.StatusCode);

                if (!result.IsSuccess)
                {
                    //ErrorResponse error = response.Content.ReadAsAsync<ErrorResponse>().Result;
                    //result.ErrorData = error;
                    var results = response.Content.ReadAsStringAsync().Result;
                    ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(results);
                    //var error = response.Content.ReadAsAsync<ErrorResponse>().Result;
                    result.ErrorData = error;
                }
                else
                {
                    result.ResponseData = response.Content.ReadAsStringAsync().Result;
                }

                return result;
            }
        }

        private static HttpClient CreateClient(bool isSecured, string jwtToken = "")
        {
            HttpClient client = null;
            if (isSecured)
            {
                //client = HttpClientFactory.Create(new SecureClientMessageHandler());
                client = new HttpClient();
            }
            else
            {
                client = new HttpClient();
            }

            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", parameter: jwtToken);
            return client;
        }

        public static string GetAppSettingsFromConfig(string key)
        { 
            return "https://localhost:44327/";
        }
         
    }
}
