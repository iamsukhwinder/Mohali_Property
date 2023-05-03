using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using Mohali_Property_Web.APICall.Admin.ManageCompany;
using System.Data;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authentication;

namespace Mohali_Property_Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly ICompanyRepository _company;
        public AdminController(ICompanyRepository company)
        {
            _company = company;
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult all_company_view()
		{
			return PartialView("/Views/Admin/ManageCompany/All_compnies.cshtml");
		}


        [HttpGet]
        public async Task<List<Company_profileVM>> GetComopanyList()
        {
            var data = await _company.GetComopanyList();
            return data;
        }

        [HttpGet]
        public async Task<List<Company_profileVM>> AddCompanyList()
        {
            var data = await _company.GetComopanyList();
            return data;
        }

        [HttpGet]
        public IActionResult add_company_view()
        {
            return PartialView("/Views/Admin/ManageCompany/AddCompanyDetail.cshtml");
        }


        [HttpPost]
        public async Task<Company_profile> AddCompanyDetail(Company_profile obj)
        {
            var data = await _company.add_company(obj);
            if (data != null)
            {


                var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Email_Image", "Registrationpage.html");
                String SendMailFrom = "bisheshdhiman5514@gmail.com";
                String SendMailTo = obj.email;
                String SendMailSubject = "Registration Successfully";

                //String SendMailBody = "<a href='http://localhost:5063/Home/Login'>Thanks for registration for us  [Please click here to login] </a>";
                String SendMailBody = System.IO.File.ReadAllText(file);
                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    MailMessage email = new MailMessage();
                    // START
                    email.From = new MailAddress(SendMailFrom);
                    email.To.Add(SendMailTo);
                    email.CC.Add(SendMailFrom);
                    email.Subject = SendMailSubject;
                    email.Body = SendMailBody;
                    email.IsBodyHtml = true;
                    //END
                    SmtpServer.Timeout = 10000;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "neenaeaznlfjlivo");
                    SmtpServer.Send(email);

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                return null;
            }
            return null;
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login","Home");
        }

    }
}
