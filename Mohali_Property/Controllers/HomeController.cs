using  Mohali_Property_Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property.Models;
using Mohali_Property_Web.APICall;
using System.Diagnostics;
using System.Security.Claims;
using Mohali_Property_Web.APICall.Login;

namespace Mohali_Property.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository _loginrepository;

        public HomeController(ILogger<HomeController> logger, ILoginRepository loginrepository)
        {
            _logger = logger;
            _loginrepository = loginrepository;
        }

        public IActionResult Index()
        {
            
            return View();
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
                        TempData["admin_name"] = data.first_name + " " + data.last_name;
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




    }
}