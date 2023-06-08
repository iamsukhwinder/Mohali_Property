using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
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

            var booling_detail =await _booking.getbookingdetail(id);
            //if(User.Identity.IsAuthenticated == true && User.IsInRole("User"))
            //{

            
            return View();

            //}
            //else
            //{
            //    return RedirectToAction("SignUp", "Home");
            //}
        }
        public async Task<IActionResult> Confirm_booking(TokenModel detail)
        {
            var result = _booking.genrate_token(detail);
            return RedirectToAction("Index","Home");
        }
    }
}
