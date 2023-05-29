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
            if(ModelState.IsValid)
            {
                DateTime created_date = DateTime.Now.Date;
                obj.created_date = created_date;
                var data = await _manageCustomer.AddCustomer(obj);
                return RedirectToAction("AddCustomer", "Customer"); 

            }
            else
            {
                return RedirectToAction("AddCustomer", "Customer");
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
