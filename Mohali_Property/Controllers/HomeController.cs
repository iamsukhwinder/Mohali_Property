
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property.Models;

using System.Diagnostics;
using System.Security.Claims;
using MohaliProperty.Model;
using MohaliProperty.Services.WebServices.Admin.Login;
using MohaliProperty.Services.WebServices.Admin.ManageKothi;
using Mohali_Property_Model;
using MohaliProperty.Services.WebServices.SignUp;
using System.Net.Mail;
using System.Net;
using MohaliProperty.Services.WebServices.Admin.ManageCustomer;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Mohali_Property.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository _loginrepository;
        private readonly IManageKothi _kothi;
        private readonly ISignUpRepository _signuprepository;
       

        public HomeController(ILogger<HomeController> logger, ILoginRepository loginrepository, IManageKothi kothi,ISignUpRepository signUpRepository)
        {
            _logger = logger;
            _loginrepository = loginrepository;
            _kothi = kothi;
            _signuprepository = signUpRepository;
           
            
        }

        public async Task<IActionResult> Index()
        {
            var kothies =await _kothi.getkothieslist();   
            
            return View(kothies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Builder()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Signout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login");

            }
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginModel obj) 
        {
            if(obj.username == null && obj.password == null)
            {
                ViewData["empty_input"] = "please fill all the fields";
                return View();
            }
            else
            {
                var data=await _loginrepository.Login(obj);

            
                if(data == null) {
                    ViewData["invalid_input"] = "username or password is incorrect"; 
                    return View();
			    }
			    else
                {
                
                        var claims = new List<Claim>();
                        claims.Add(new Claim("username", data.username));
                        claims.Add(new Claim(ClaimTypes.Role, data.role_name));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, data.username));
                        claims.Add(new Claim(ClaimTypes.Name, data.username ));
            
                        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimPrinciple = new ClaimsPrincipal(claimIdentity);
                        HttpContext.SignInAsync(claimPrinciple);
                        if (data.role_name == "Admin")
                        {
                        TempData["admin_name"] = data.name;
                        return RedirectToAction("Index", "Admin");
                        }
                        else if(data.role_name == "User")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            HttpContext.Session.SetString("customer_id", data.id.ToString());
                            return RedirectToAction("Index", "Home");
                        }
        

                }
             }

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        //[HttpGet]
        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task <IActionResult> SignUp(CustomerModel obj)
        //{
        //    var data = await _manageCustomer.AddCustomer(obj);
           
        //    if (data != null)
        //    {


        //        var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Email_Image", "Registrationpage.html");
        //        String SendMailFrom = "bisheshdhiman5514@gmail.com";
        //        String SendMailTo = obj.customer_email;
        //        String SendMailSubject = "Registration Successfully";
        //        // String SendMailBody = "<a href='http://localhost:5063/Home/Login'>Thanks for registration for us  [Please click here to login] </a>";
        //        String SendMailBody = System.IO.File.ReadAllText(file);
        //        try
        //        {
        //            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
        //            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            MailMessage email = new MailMessage();
        //            // START
        //            email.From = new MailAddress(SendMailFrom);
        //            email.To.Add(SendMailTo);
        //            email.CC.Add(SendMailFrom);
        //            email.Subject = SendMailSubject;
        //            email.Body = SendMailBody;
        //            email.IsBodyHtml = true;
        //            //END
        //            SmtpServer.Timeout = 10000;
        //            SmtpServer.EnableSsl = true;
        //            SmtpServer.UseDefaultCredentials = false;
        //            SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "neenaeaznlfjlivo");
        //            SmtpServer.Send(email);

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(UserModel useremail)
        {
            var user =await _loginrepository.checkuserbyemail(useremail.email); 
            if(user.is_success == false)
            {
                TempData["Not_exist"] = user.message;
                return View();
            }
            else
            {
                TempData["exist"] = "We have sent you the Reset password link on your email";
                SendEmail mail = new SendEmail();
                var tosend = useremail.email;
                var subject = "Reset Password";
                var body = "<a href='http://localhost:5130/Home/ResetPassword?email=" + useremail.email + "' > Click on me to reset your password</a>";
                mail.Sendmail(tosend, subject, body);
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult ResetPassword(string email)
        
        {
            ViewData["user_email"] = email;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(LoginModel logdetail)
        {
            var result =await _loginrepository.updatepassword(logdetail);
            if(result.is_success == false)
            {
                TempData["Not_exist"] = result.message;
                return RedirectToAction("ForgotPassword", "Home");
            }
            else
            {
                TempData["Updated"] = result.message;
                return RedirectToAction("Login", "Home");
            }
        }




    }
}