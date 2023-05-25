using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using MohaliProperty.Services.WebServices.Admin.ManageCustomer;

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
            var data = await _manageCustomer.AddCustomer(obj);
            return RedirectToAction("AddCustomer", "Customer"); 
        }


    }
}
