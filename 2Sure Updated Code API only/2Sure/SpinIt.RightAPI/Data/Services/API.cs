using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpinIt.Data.Services
{
    public class API
    {
        public IHttpContextAccessor _httpContext;
        public API(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public HttpClient Initial()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44342/");

            //var key = _httpContext.HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + key);

            return client;
        }

    }
}
