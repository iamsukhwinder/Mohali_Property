using Mohali_Property_Model;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Mohali_Property_Web.Extension.Configuration;

namespace Mohali_Property_Web.APICall.Admin.ManageToken
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddToken(TokenModel token)
        {
            var url = "/api/TokenApi/add_token";
            var response = await ApiCall.Initial(_configuration).PostAsJsonAsync(url, token);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var usrDetail = JsonConvert.DeserializeObject<int>(stringResponse);
                return usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return 0;
            }
        }

        public async Task<List<TokenVM>> gettokenlists()
        {
            var url = "/api/TokenApi/gettokenlist";

            var response = await ApiCall.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<List<TokenVM>>(stringResponse);
                return _usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }

        public async Task<int> delete_token(int id)
        {
            var url = "/api/TokenApi/delete_token?id="+id;

            var response = await ApiCall.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<int>(stringResponse);
                return _usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return 0;
            }
        }
    }
}
