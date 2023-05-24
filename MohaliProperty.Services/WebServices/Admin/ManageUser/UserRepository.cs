﻿using Microsoft.Extensions.Configuration;
using Mohali_Property_Model;
using MohaliProperty.Extensions.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.ManageUser
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> add_user(UserModel user)
        {
            var url = "/api/User/add_user";
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url,user);
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

        public async Task<List<UserVM>> GetUserList()
        {
            var url = "/api/User/GetUserList";
            var response = await Configurations.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var usrDetail = JsonConvert.DeserializeObject<List<UserVM>>(stringResponse);
                return usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }

        }
    }
}
