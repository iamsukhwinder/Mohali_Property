using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Mohali_Property_Model;
using MohaliProperty.Services.WebServices.Admin.ManageCustomer;
using System.Net;
using System.Net.Mail;

namespace MohaliProperty.Web.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IManageCustomer _manageCustomer;

        public CustomerController(IManageCustomer manageCustomer)
        {
            _manageCustomer = manageCustomer;

        }
        
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCustomer()
        {
            return View("~/Views/Admin/Customer/ShowCustomer.cshtml");
        }

        [HttpGet]
        public async Task<List<CustomerModel>> ShowCustomerList()
        {
            var customers = await _manageCustomer.getcustomerlist();
            return customers;
        }

        public IActionResult AddCustomer()
        {
            return View("~/Views/Admin/Customer/AddCustomer.cshtml");
        }

        [HttpPost]  
        public async Task <IActionResult> AddCustomer(CustomerModel obj)
        {
            if(ModelState.IsValid)
            {
                DateTime created_date = DateTime.Now.Date;
                obj.created_date = created_date;
                var data = await _manageCustomer.AddCustomer(obj);

                
                var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Email_Image", "Registrationpage.html");
                String SendMailFrom = "bisheshdhiman5514@gmail.com";
                String SendMailTo = obj.customer_email;
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
                    string i = ("<img src=https://media.publit.io/file/q_80/chrmpWebsite/thank-you-form.png>"+"<br><br><br>");
                    string v = ("Thanks for Registration Your username is -->" + obj.customer_email + " and your password is--> " + obj.mobile_number)+"<br>"+("<a href='http://localhost:5130/Home/Login'>Thanks for registration for us  [Please click here to login] </a>");
                    email.Body = i + v;
                    email.IsBodyHtml = true;
                    //END
                    SmtpServer.Timeout = 10000;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "neenaeaznlfjlivo");
                    SmtpServer.Send(email);

                return View();


                }
                catch (Exception ex)
                {

                }
                if (data != null)
                {
                    TempData["success_msg"] = "Succesfull SignUp";
                    return RedirectToAction("SignUp", "Home");
                }
            }
            else
            {

                return null;
            }

        }

        [HttpGet]
        public async Task <IActionResult> Editcustomer(int id)
        {
            var data = await _manageCustomer.EditCustomer(id);
            return PartialView("~/Views/Admin/Customer/_Editcustomer.cshtml",data);
        }

        [HttpPost]
        public async Task<int> UpdateCustomer(CustomerModel obj)
        {
            var data = await _manageCustomer.UpdateCustomer(obj);
            return data;
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var data = await _manageCustomer.Deletecustomer(id);
            return data;
        }


    }
}
