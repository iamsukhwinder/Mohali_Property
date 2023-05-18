using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.ManageKothi
{
    public class ManageKothi : IManageKothi
    {
        private readonly IConfiguration _configuration;
        public ManageKothi(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<int> Add_Kothi(KothiModel kothiModel)
        {
            var url = "/api/Admin/AddKothi";
            var response = await ApiCall.Initial(_configuration).PostAsJsonAsync(url, kothiModel);
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

        public async Task<int> delete_kothi(int id)
        {
            var url = "/api/Admin/DeleteKothi?id=" + id;

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

        public async Task<KothiModel> Edit_kothi(int id)
        {
            var url = "/api/Admin/editKothi?id=" + id;

            var response = await ApiCall.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<KothiModel>(stringResponse);
                return _usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
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

        public async Task<int> update_kothi(KothiModel obj)
        {
            var url = "/api/Admin/updateKothi";
            var response = await ApiCall.Initial(_configuration).PostAsJsonAsync(url, obj);
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
