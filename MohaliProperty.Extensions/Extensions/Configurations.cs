using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
//using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;


namespace MohaliProperty.Extensions.Extensions
{
    public static class Configurations
    {
        private static IConfiguration _configuration;

        public static HttpClient Initial(IConfiguration configuration)
        {
            _configuration = configuration;
            var baseurl = _configuration.GetValue<string>("WebAPIBaseUrl");
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }


    }
}
