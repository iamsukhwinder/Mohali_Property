using System.Net.Http.Headers;

namespace Mohali_Property_Web.Extension
{
    public class Configuration
    {
        public static class ApiCall
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
}
