using Microsoft.Extensions.Configuration;
using Mohali_Property_Model;
using MohaliProperty.Extensions.Extensions;
using MohaliProperty.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.ManageCustomer
{
    public class ManageCustomer : IManageCustomer
    {
        private readonly IConfiguration _configuration;
        public ManageCustomer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddCustomer(CustomerModel obj)
        {
            var url = "/api/Customer/add_customer";
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url,obj);
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

        
        public async Task<CustomerModel> EditCustomer(int id)
        {
            var url = "/api/Customer/editcustomer?id=" + id;

            var response = await Configurations.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var _usrDetail = JsonConvert.DeserializeObject<CustomerModel>(stringResponse);
                return _usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }


        public async Task<List<CustomerModel>> getcustomerlist()
        {
            var url = "/api/Customer/customer_list";
            var response = await Configurations.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var usrDetail = JsonConvert.DeserializeObject<List<CustomerModel>>(stringResponse);
                return usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }

        public async Task<int> UpdateCustomer(CustomerModel obj)
        {
            var url = "/api/Customer/updatecustomer";
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


        public async Task<int> Deletecustomer(int id)
        {
            var url = "/api/Customer/Deletecustomer?id=" + id;

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
