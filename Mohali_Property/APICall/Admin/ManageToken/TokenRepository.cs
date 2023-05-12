using Mohali_Property_Model;
using Newtonsoft.Json;
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
    }
}
