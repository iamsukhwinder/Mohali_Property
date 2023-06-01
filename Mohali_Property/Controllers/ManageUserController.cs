using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using MohaliProperty.Services.WebServices.Admin.ManageUser;

namespace MohaliProperty.Web.Controllers
{
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

        //[HttpGet]
        //public async Task<List<UserModel>> addUserList()
        //{
        //    var data = await _User.GetUserList();
        //    return data;
        //}

        [HttpPost]
        public async Task<int> Adduser(UserModel user)
        {
            var result = await _User.add_user(user);
            return result;
        }

        [HttpGet]
        public IActionResult Add_User()
        {
            return View();
        }



    }
}
