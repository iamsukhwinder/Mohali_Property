using Microsoft.AspNetCore.Mvc;

namespace Mohali_Property_Web.Controllers
{
    public class KothiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult showkothies()
        {
            return PartialView("/Views/Admin/ManageKothi/All_kothies.cshtml");
        }
    }
}
