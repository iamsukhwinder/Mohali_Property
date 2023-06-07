using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using MohaliProperty.Model;
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
