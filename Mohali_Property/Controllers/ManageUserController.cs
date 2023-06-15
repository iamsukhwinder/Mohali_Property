using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using MohaliProperty.Model;
using MohaliProperty.Services.WebServices.Admin.ManageUser;
using System.Net.Mail;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MohaliProperty.Web.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class ManageUserController : Controller
    {
        private readonly IUserRepository _company;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly IUserRepository _User;

        public ManageUserController(IUserRepository company, IWebHostEnvironment hostEnvironment, IUserRepository user)
        {
            _hostingEnvironment = hostEnvironment;
            _company = company;
            _User = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult All_User()
        {
            return View();
        }


        [HttpGet]
        public async Task<List<UserVM>> GetUserList()
        {
            var data = await _User.GetUserList();
            return data;
        }


        [HttpPost]
        public async Task<IActionResult> Add_User(UserModel user)

        {

            if (ModelState.IsValid)
            {
                var result = await _User.add_user(user);
                if (result == 3)
                {
                    TempData["msg1"] = "Email is already registered";
                    return View();
                }
                else
                {
                    var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Email_Image", "Userpage.html");
                    string SendMailFrom = "bisheshdhiman5514@gmail.com";
                    string SendMailTo = user.email;
                    string SendMailSubject = "User Added Successfully";
                    //String SendMailBody = "<a href='http://localhost:5063/Home/Login'>Thanks for registration for us  [Please click here to login] </a>";
                    string SendMailBody = System.IO.File.ReadAllText(file);
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
                        string i = ("<img src=https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSz5MsCaAm0-KUEDWmYAoXmQYpyNobrAT8DXg&usqp=CAU>" + "<br><br><br>");
                        string v = (" Your username is -->" + user.email + " and your password is--> " + user.mobile_number) + "<br>" + ("<a href='http://localhost:5130/Home/Login'>  [Please click here to login] </a>");
                        email.Body = i + v;
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
                        return View();
                    }
                    TempData["msg2"] = "User Added Successfully. Username and password is sent to user email";
                    return View();
                }

            }
            else
            {
                return View();

            }

        }

        [HttpGet]
        public IActionResult Add_User()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var useres = await _User.edit_users(id);
            return PartialView("/Views/ManageUser/Edit_user.cshtml",useres);


        }


        [HttpPost]
        public async Task<int> update_user(UserVM user)
        {
            var useres = await _User.update_users(user);
            if (useres == null && useres.is_success == false)
            {
                return useres.status_code;
            }
            else
            {
                return useres.status_code;
            }
        }



        public async Task<int> delete_user(int id)
        {
            var useres = await _User.delete_user(id);
            return useres;
        }
    }


}
