using Microsoft.Extensions.Configuration;
using MohaliProperty.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohaliProperty.Extensions;
using MohaliProperty.Extensions.Extensions;
using System.Net.Http.Json;

namespace MohaliProperty.Services.WebServices.Admin.ManageCompany
{
    public class CompanyRepsoitory : ICompanyRepository
    {
        private readonly IConfiguration _configuration;
        public CompanyRepsoitory(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<int> add_company(Company_profileVM data)
        {
            var url = "/api/Admin/add_company";
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url, data);
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

        public async Task<List<Company_profileVM>> GetComopanyList()
        {
            var url = "/api/Admin/GetComopanyList";

            var response = await Configurations.Initial(_configuration).GetAsync(url);
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

       
        public async Task<Company_profileVM> Editcompany(int id)//int id)
        {
            var url = "/api/Admin/editcompany?id=" + id;

            var response = await Configurations.Initial(_configuration).GetAsync(url);
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
        public async Task<int> update_company(Company_profileVM obj)
        {
            var url = "/api/Admin/update_company";
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url, obj);
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
        public async Task<int> Deletecompany(int id)
        {
            var url = "/api/Admin/Deletecompany?id=" + id;

            var response = await Configurations.Initial(_configuration).GetAsync(url);
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
