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
            
            var user = User.IsInRole("Customer");
            if (User.IsInRole("Customer"))
            {
                var booking_detail = await _booking.getbookingdetail(id);

                ViewData["customer_id"] = HttpContext.Session.GetString("customer_id");
                return View(booking_detail.data);
            }
            else
            {
                TempData["not_cutomer"] = "please login first as customer to book";
                return RedirectToAction("Index", "Home");
            }


            //}
            //else
            //{
            //    return RedirectToAction("SignUp", "Home");
            //}
        }
        public async Task<IActionResult> Confirm_booking(TokenModel detail)
        {
            var result =await _booking.genrate_token(detail);
            if(result.is_success == false)
            {
                TempData["fail"] = "Something wrong please try again";
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["success"] = "Kothi booked successfully";
                return RedirectToAction("Index","Home");
            }
        }
    }
}
