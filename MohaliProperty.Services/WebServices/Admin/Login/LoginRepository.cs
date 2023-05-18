using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MohaliProperty.Extensions.Extensions;
using MohaliProperty.Model;
using Newtonsoft.Json;

namespace MohaliProperty.Services.WebServices.Admin.Login
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
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url, obj);
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




