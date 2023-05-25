using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authentication;
using System.Globalization;
using MohaliProperty.Model;
using MohaliProperty.Services.WebServices.Admin.ManageCompany;
using MohaliProperty.Services.WebServices.Admin.ManageKothi;

namespace MohaliProperty.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly ICompanyRepository _company;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly IManageKothi _kothi;
        public AdminController(ICompanyRepository company, IWebHostEnvironment hostEnvironment, IManageKothi kothi)  
        {
            _hostingEnvironment = hostEnvironment;
            _company = company;
            _kothi = kothi;
        }
        public async Task<IActionResult> Index()
		{
            var kothies = await _kothi.getkothieslist();
            var kothi_count = kothies.Count;
            ViewData["kothi_count"] = kothi_count;

            List<KothiModel> available_kothies = new List<KothiModel>();
            foreach (var kothi in kothies)
            {
                if(kothi.status == "Active" && kothi.hold == 1)
                {
                    available_kothies.Add(kothi);
                }
            }
            var available_kothies_count = available_kothies.Count;
            ViewData["available_kothies_count"] = available_kothies_count;

            List<KothiModel> Hold_kothies = new List<KothiModel>();
            foreach (var kothi in kothies)
            {
                if (kothi.hold == 2)
                {
                    Hold_kothies.Add(kothi);
                }
            }
            var Hold_kothies_count = Hold_kothies.Count;
            ViewData["Hold_kothies"] = Hold_kothies_count;
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


        [HttpGet]
        public async Task<IActionResult> Editcompany(int id)
        {
            var company = await _company.Editcompany(id);
            return PartialView("~/Views/Admin/ManageCompany/Editcompany.cshtml",company);
        }


        



        [HttpPost]
        public async Task<int> AddCompanyDetail(IFormCollection obj, Company_profileVM company_ProfileVM)
        {
            if (ModelState.IsValid)
            {
            if(obj.Files.Count >= 2)
            {
                return 301;
            }
            if (obj.Files[0].ContentType != "image/jpeg" && obj.Files[0].ContentType != "image/png" && obj.Files[0].ContentType != "image/jpg")
            {
                return 300;
            }


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
           

            else
            {
                return 0;

            }
        }
        [HttpPost]
        public async Task<int> update_company(IFormCollection obj)
        {
            
            if (obj.Files.Count >= 2)
            {
                return 301;
            }
            
            
            
            if (obj.Files.Count != 0)
            {
                if (obj.Files[0].ContentType != "image/jpeg" && obj.Files[0].ContentType != "image/png" && obj.Files[0].ContentType != "image/jpg")
                {
                    return 300;
                }
                var file = obj.Files[0];
                var size = file.Length;
                int company_id = Convert.ToInt32(obj["company_id"]);
                string company = obj["company"];
                string company_name = obj["company_name"];
                string company_address = obj["company_address"];
                string city = obj["city"];
                string state = obj["State"];
                string pin_code = obj["pin_code"];
                string website = obj["website"];
                string gst_number = obj["gst_number"];
                string status = obj["status"];
                string company_logo = file.FileName;
                string mobileNumber = obj["mobilenumber"];
                string landlineNo = obj["landlineNo"];
                string email = obj["email"];

                var webPath = _hostingEnvironment.WebRootPath;
                var filePath = Path.Combine(webPath, "Admin/images/company_logo");
                filePath = Path.Combine(filePath, file.FileName);
                Company_profileVM comp = new Company_profileVM();
                comp.company_id = company_id;
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
               

                var result = await _company.update_company(comp);
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                }
                return result;
                              
                }
            else
            {
                
                int company_id = Convert.ToInt32(obj["company_id"]);
                string company = obj["company"];
                string company_name = obj["company_name"];
                string company_address = obj["company_address"];
                string city = obj["city"];
                string state = obj["State"];
                string pin_code = obj["pin_code"];
                string website = obj["website"];
                string gst_number = obj["gst_number"];
                string status = obj["status"];
                string company_logo = obj["company_logo"];
                string mobileNumber = obj["mobilenumber"];
                string landlineNo = obj["landlineNo"];
                string email = obj["email"];

               
                Company_profileVM comp = new Company_profileVM();
                comp.company_id = company_id;
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
                var result = await _company.update_company(comp);
                return result;
            }
        }

        public async Task<int> DeleteCompany(int id)
        {
            var data = await _company.Deletecompany(id);
            return data;
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login","Home");
        }

    }
}
