using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohali_Property_Model;

namespace MohaliProperty.Services.WebServices.Booking
{
    public interface IBookingRepository
    {
        public Task<ResponseModel<BookingModel>> getbookingdetail(int id);
    }
}
