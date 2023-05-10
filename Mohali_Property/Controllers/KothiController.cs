using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using Mohali_Property_Web.APICall.Admin.ManageCompany;
using Mohali_Property_Web.APICall.Admin.ManageKothi;

namespace Mohali_Property_Web.Controllers
{
    public class KothiController : Controller
    {
        private readonly IManageKothi _kothi;
        private IWebHostEnvironment _hostingEnvironment;
        public KothiController(IManageKothi kothi, IWebHostEnvironment hostEnvironment)
        {
            _hostingEnvironment = hostEnvironment;
            _kothi = kothi;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult showkothies()
        {
            return PartialView("/Views/Admin/ManageKothi/All_kothies.cshtml");
        }

        public async Task<List<KothiModel>> getkothieslist()
        {
            var kothies = await _kothi.getkothieslist();
            return kothies;
        }
    }
}
