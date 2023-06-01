using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authentication;
using System.Globalization;
using MohaliProperty.Model;
using MohaliProperty.Services.WebServices.Admin.ManageCompany;
using MohaliProperty.Services.WebServices.Admin.ManageKothi;

namespace MohaliProperty.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
       
        private IWebHostEnvironment _hostingEnvironment;
        private readonly IManageKothi _kothi;
        public AdminController(IWebHostEnvironment hostEnvironment, IManageKothi kothi)  
        {
            _hostingEnvironment = hostEnvironment;
          
            _kothi = kothi;
        }
        public async Task<IActionResult> Index()
		{
            var kothies = await _kothi.getkothieslist();
            var kothi_count = kothies.Count;
            ViewData["kothi_count"] = kothi_count;

            List<KothiModel> available_kothies = new List<KothiModel>();
            foreach (var kothi in kothies)
            {
                if(kothi.status == "Active" && kothi.hold == 1)
                {
                    available_kothies.Add(kothi);
                }
            }
            var available_kothies_count = available_kothies.Count;
            ViewData["available_kothies_count"] = available_kothies_count;

            List<KothiModel> Hold_kothies = new List<KothiModel>();
            foreach (var kothi in kothies)
            {
                if (kothi.hold == 2)
                {
                    Hold_kothies.Add(kothi);
                }
            }
            var Hold_kothies_count = Hold_kothies.Count;
            ViewData["Hold_kothies"] = Hold_kothies_count;
            return View();
		}
		
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login","Home");
        }

    }
}
