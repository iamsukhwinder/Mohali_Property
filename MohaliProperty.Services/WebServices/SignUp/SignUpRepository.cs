using Microsoft.Extensions.Configuration;
using Mohali_Property_Model;
using MohaliProperty.Extensions.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.SignUp
{
    public class SignUp : ISignUpRepository
    {
        private readonly IConfiguration _configuration;
        public SignUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> signup(CustomerModel obj)
        {
            var url = "/api/SignUp/signup";
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url, obj);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var usrDetail = JsonConvert.DeserializeObject<int>(stringResponse);
                return usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return 1;
            }
        }

        
    }
}
