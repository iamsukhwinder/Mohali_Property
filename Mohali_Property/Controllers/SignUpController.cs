using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using System.Net.Mail;
using System.Net;
using MohaliProperty.Services.WebServices.Admin.ManageCustomer;

namespace MohaliProperty.Web.Controllers
{
    public class SignUpController : Controller
    {

        private readonly IManageCustomer _manageCustomer;

        public SignUpController(IManageCustomer manageCustomer)
        {
            _manageCustomer = manageCustomer;

        }
        // GET: SignUpController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CustomerModel obj)
        {
            if (ModelState.IsValid)
            {
                DateTime created_date = DateTime.Now.Date;  
                obj.created_date = created_date;
                var data = await _manageCustomer.AddCustomer(obj);
                if (data == 3)
                {
                    TempData["msg"] = "Email is already registered";
                    return RedirectToAction("SignUp", "SignUp");
                }
                else
                {

                       
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
                        string i = ("<img src=https://media.publit.io/file/q_80/chrmpWebsite/thank-you-form.png>" + "<br><br><br>");
                        string v = ("Thanks for Registration Your username is -->" + obj.customer_email + " and your password is--> " + obj.mobile_number) + "<br>" + ("<a href='http://localhost:5130/Home/Login'>Thanks for registration for us  [Please click here to login] </a>");
                        email.Body = i + v;
                        email.IsBodyHtml = true;
                        //END
                        SmtpServer.Timeout = 10000;
                        SmtpServer.EnableSsl = true;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "neenaeaznlfjlivo");
                        SmtpServer.Send(email);

                        TempData["success_msg"] = "Succesfull SignUp--> Please Check your Email for Username and Password";
                        return RedirectToAction("SignUp", "SignUp");


                    }
                    catch (Exception ex)
                    {
                        return View();
                    }
                }   
               
            }
            else
            {

            return View();
                //    // return View("SignUp", "Home");
                //    return RedirectToAction("SignUp", "SignUp");
            }
            //   return View("SignUp", "Home");

        }

    }
}
