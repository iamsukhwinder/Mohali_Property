
using Mohali_Property_Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static Mohali_Property_Web.Extension.Configuration;

namespace Mohali_Property_Web.APICall.Login
{
    public class LoginRepository : ILoginRepository
    {

        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<LoginVM> Login(LoginModel obj)
        {
            var url = "/api/Login/Login";
            var response = await ApiCall.Initial(_configuration).PostAsJsonAsync(url, obj);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                LoginVM _usrDetail = JsonConvert.DeserializeObject<LoginVM>(stringResponse);
                return _usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }


    }
}



