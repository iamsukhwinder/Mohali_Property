using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using Mohali_Property_Web.APICall.Admin.ManageCompany;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Globalization;

namespace Mohali_Property_Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly ICompanyRepository _company;
        private IWebHostEnvironment _hostingEnvironment;
        public AdminController(ICompanyRepository company, IWebHostEnvironment hostEnvironment) 
        {
            _hostingEnvironment = hostEnvironment;
            _company = company;
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult all_company_view()
		{
			return PartialView("/Views/Admin/ManageCompany/All_compnies.cshtml");
		}


        [HttpGet]
        public async Task<List<Company_profileVM>> GetComopanyList()
        {
            var data = await _company.GetComopanyList();
            return data;
        }

        [HttpGet]
        public async Task<List<Company_profileVM>> AddCompanyList()
        {
            var data = await _company.GetComopanyList();
            return data;
        }

        [HttpGet]
        public IActionResult add_company_view()
        {
            return PartialView("/Views/Admin/ManageCompany/AddCompanyDetail.cshtml");
        }


        [HttpPost]
        public async Task<int> AddCompanyDetail(IFormCollection obj)
        {
            if (obj.Files.Count != 0)
            {
                var file = obj.Files[0];
                var size = file.Length;
                string company = obj["company"];
                string company_name = obj["companyname"];
                string company_address = obj["address"];
                string city = obj["city"];
                string state = obj["State"];
                string pin_code = obj["pincode"];
                string website = obj["website"];
                string gst_number = obj["gst"];
                string status = obj["status"];
                string company_logo = file.FileName;
                string mobileNumber = obj["mobilenumber"];
                string landlineNo = obj["landlinenumber"];
                string email = obj["email"];
               
                var webPath = _hostingEnvironment.WebRootPath;
                var filePath = Path.Combine(webPath, "Admin/images/company_logo");
                filePath = Path.Combine(filePath, file.FileName);
                Company_profileVM comp = new Company_profileVM();
                comp.company = company;
                comp.company_name = company_name;
                comp.company_address = company_address;
                comp.city = city;
                comp.state = state;
                comp.pin_code = pin_code;
                comp.website = website;
                comp.gst_number = gst_number;
                comp.status = status;
                comp.company_logo = company_logo;
                comp.mobileNumber = mobileNumber;
                comp.landlineNo = landlineNo;
                comp.email = email;

                var result = await _company.add_company(comp);
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                }
                return result;
              
            
            
            }
            else
            {
                return 0;

            }
        }


    }
}
