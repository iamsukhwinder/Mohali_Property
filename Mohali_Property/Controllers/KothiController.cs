using Microsoft.AspNetCore.Mvc;

namespace Mohali_Property_Web.Controllers
{
    public class KothiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add_Kothi()
        {
            var check = PartialView("/Views/Admin/ManageKothi/Add_Kothi.cshtml");
            return check;
        }



        public IActionResult showkothies()
        {
            return PartialView("/Views/Admin/ManageKothi/All_kothies.cshtml");
        }
    }
}
