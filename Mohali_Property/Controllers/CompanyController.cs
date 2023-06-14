using Microsoft.AspNetCore.Mvc;
using MohaliProperty.Model;
using MohaliProperty.Services.WebServices.Admin.ManageCompany;

namespace MohaliProperty.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _company;
        private IWebHostEnvironment _hostingEnvironment;
        public CompanyController(ICompanyRepository company, IWebHostEnvironment hostEnvironment)
        {
            _company = company;
            _hostingEnvironment = hostEnvironment;
        }


        [HttpGet]
        public IActionResult All_compnies()
        {
            return View();
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
        public async Task<IActionResult> Editcompany(int id)
        {
            var company = await _company.Editcompany(id);
            return PartialView("~/Views/Company/Editcompany.cshtml", company);
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddCompany(IFormCollection obj, Company_profileVM company_ProfileVM)
        {
            if (obj.Files.Count >= 2)
            {
                ViewData["not_allowed"] = "multiple images are not allowed";
                return View();
            }
            if (obj.Files.Count != 0)
            {
                if (obj.Files[0].ContentType != "image/jpeg" && obj.Files[0].ContentType != "image/png" && obj.Files[0].ContentType != "image/jpg")
                {
                    ViewData["not_allowed"] = "Upload only jpeg,png,jpg";
                    return View();
                }
                if (ModelState.IsValid)
                {

                        var file = obj.Files[0];
                        var size = file.Length;
                        string company = company_ProfileVM.company;
                        string company_name = company_ProfileVM.company_name;
                        string company_address = company_ProfileVM.company_address;
                        string city = company_ProfileVM.city;
                        string state = company_ProfileVM.state;
                        string pin_code = company_ProfileVM.pin_code;
                        string website = company_ProfileVM.website;
                        string gst_number = company_ProfileVM.gst_number;
                        string status = company_ProfileVM.status;
                        string company_logo = file.FileName;
                        string mobileNumber = company_ProfileVM.mobileNumber;
                        string landlineNo = company_ProfileVM.landlineNo;
                        string email = company_ProfileVM.email;

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
                        if(result == 1)
                        {
                            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ViewData["company_added"] = "company added";
                            return View();
                        }
                        else
                        {
                            ViewData["company_not_added"] = "company not added";
                            return View();
                        }
                    

                    }
                else
                {
                    return View();
                }
            }


            else
            {
                ViewData["empty_image"] = "please choose an image";
                return View();

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
    }
}
