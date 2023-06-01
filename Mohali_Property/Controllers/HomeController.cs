﻿
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
using System.Numerics;

namespace Mohali_Property.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository _loginrepository;
        private readonly IManageKothi _kothi;

        public HomeController(ILogger<HomeController> logger, ILoginRepository loginrepository, IManageKothi kothi)
        {
            _logger = logger;
            _loginrepository = loginrepository;
            _kothi = kothi;
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
                        claims.Add(new Claim(ClaimTypes.Name, data.password + " " + data.password));
            
                        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimPrinciple = new ClaimsPrincipal(claimIdentity);
                        HttpContext.SignInAsync(claimPrinciple);
                        if (data.role_name == "Admin")
                        {
                        TempData["admin_name"] = data.name;
                        return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "User");
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