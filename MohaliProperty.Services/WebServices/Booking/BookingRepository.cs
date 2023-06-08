using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mohali_Property_Model;
using MohaliProperty.Extensions.Extensions;
using Newtonsoft.Json;

namespace MohaliProperty.Services.WebServices.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConfiguration _configuration;
        public BookingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseModel<int>> genrate_token(TokenModel detail)
        {
            var url = "/api/BookingApi/generate_token";
            var response = await Configurations.Initial(_configuration).PostAsJsonAsync(url,detail);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var usrDetail = JsonConvert.DeserializeObject<ResponseModel<int>>(stringResponse);
                return usrDetail;
            }
            else
            {
                Console.WriteLine("Internal server Error");
                return null;
            }
        }

        public async Task<ResponseModel<BookingModel>> getbookingdetail(int id)
        {
            var url = "/api/BookingApi/getbookingdetail?id="+ id;
            var response = await Configurations.Initial(_configuration).GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var usrDetail = JsonConvert.DeserializeObject<ResponseModel<BookingModel>>(stringResponse);
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
