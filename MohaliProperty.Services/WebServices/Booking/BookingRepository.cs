using System;
using System.Collections.Generic;
using System.Linq;
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
