using Microsoft.AspNetCore.Mvc;
using MohaliProperty.Services.WebServices.Admin.ManageKothi;
using MohaliProperty.Services.WebServices.Booking;

namespace MohaliProperty.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IManageKothi _kothi;
        private readonly IBookingRepository _booking;
        public BookingController(IManageKothi kothi,IBookingRepository booking)
        {
            _kothi = kothi;
            _booking = booking;
        }
        public async Task<IActionResult> Index(int id)
        {

            var booking_detail =await _booking.getbookingdetail(id);
            //if(User.Identity.IsAuthenticated == true && User.IsInRole("User"))
            //{

            
            return View(booking_detail.data);

            //}
            //else
            //{
            //    return RedirectToAction("SignUp", "Home");
            //}
        }
    }
}
