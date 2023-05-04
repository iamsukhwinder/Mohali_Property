using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using Mohali_Property_Web.Extension;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static Mohali_Property_Web.Extension.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mohali_Property_Web.APICall.Admin.ManageCompany
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConfiguration _configuration;
        public CompanyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<int> add_company(Company_profileVM data)
        {
            var url = "/api/Admin/add_company";
            var response = await ApiCall.Initial(_configuration).PostAsJsonAsync(url, data);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
              var usrDetail = JsonConvert.DeserializeObject<int>(stringResponse);
                return usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return 0 ; 
            }
        }

        public async Task<List<Company_profileVM>> GetComopanyList()
        {
            var url = "/api/Admin/GetComopanyList";

            var response = await ApiCall.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<List<Company_profileVM>>(stringResponse);
                return _usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }

        [HttpGet]
        public async Task<Company_profileVM> Editcompany(int id)//int id)
        {
            var url = "/api/Admin/Editcompany",id;

            var response = await ApiCall.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<Company_profileVM>(stringResponse);
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
   

