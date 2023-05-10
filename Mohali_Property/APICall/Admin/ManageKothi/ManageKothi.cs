using Mohali_Property_Model;
using Newtonsoft.Json;
using static Mohali_Property_Web.Extension.Configuration;

namespace Mohali_Property_Web.APICall.Admin.ManageKothi
{
    public class ManageKothi : IManageKothi
    {
        private readonly IConfiguration _configuration;
        public ManageKothi(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<KothiModel>> getkothieslist()
        {
            var url = "/api/Admin/GetKothiList";

            var response = await ApiCall.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<List<KothiModel>>(stringResponse);
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
