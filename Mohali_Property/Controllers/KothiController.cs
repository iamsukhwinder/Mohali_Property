using Microsoft.AspNetCore.Mvc;
using MohaliProperty.Model;

using MohaliProperty.Services.WebServices.Admin.ManageKothi;

namespace Mohali_Property_Web.Controllers
{
    public class KothiController : Controller
    {
        private readonly IManageKothi _kothi;
        private IWebHostEnvironment _hostingEnvironment;
        public KothiController(IManageKothi kothi, IWebHostEnvironment hostEnvironment)
        {
            _hostingEnvironment = hostEnvironment;
            _kothi = kothi;
        }
        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult Add_Kothi()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add_Kothi(IFormCollection kothi_image,KothiModel kothidata)

        {

            if (kothi_image.Files.Count >= 2)
            {
                ViewData["multiple_not_valid"] = "* multiple images are not allowed";
                return View();
            }
            if (kothi_image.Files[0].ContentType != "image/jpeg" && kothi_image.Files[0].ContentType != "image/png" && kothi_image.Files[0].ContentType != "image/jpg")
            {
                ViewData["image_type"] = "* image type is invalid upload only jpeg,png,jpg";
                return View();

            }

            if(ModelState.IsValid)
            {
               
            if (kothi_image.Files.Count != 0)
            {
                var file = kothi_image.Files[0];
                var size = file.Length;
                string kothi_image_name = file.FileName;

                var webPath = _hostingEnvironment.WebRootPath;
                var filePath = Path.Combine(webPath, "Image/kothi_images");
                filePath = Path.Combine(filePath, kothidata.kothi_Number + file.FileName);
                KothiModel kothi = new KothiModel();
                kothi.kothi_Number = kothidata.kothi_Number;
                kothi.block = kothidata.block;
                kothi.kothi_size = kothidata.kothi_size;
                kothi.kothi_description = kothidata.kothi_description;
                kothi.dimension = kothidata.dimension;
                kothi.plot_area = kothidata.plot_area;
                kothi.price = kothidata.price;
                kothi.bhk = kothidata.bhk;
                kothi.booking_amount = kothidata.booking_amount;
                kothi.status = kothidata.status;
                kothi.kothi_image = kothidata.kothi_Number + file.FileName;
                kothi.hold = 1;

                var result = await _kothi.Add_Kothi(kothi);
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                }
                    return View();


                }
                else
                {
                    return View();
                }
            }

            else
            {

                return View();


            }

        }

 
        public IActionResult showkothies()
        {
            return View();
        }

        public async Task<List<KothiModel>> getkothieslist()
        {
            var kothies = await _kothi.getkothieslist();
            return kothies;
        }
        [HttpGet]
        public async Task<IActionResult> Edit_kothi(int id)
        {
            var kothies = await _kothi.Edit_kothi(id);
            return View(kothies);
          

        }


        [HttpPost]
        public async Task<int> update_kothi(KothiModel kothi)
        {
            var kothies = await _kothi.update_kothi(kothi);
            if (kothies == null && kothies.is_success == false)
            {
                return kothies.status_code;
            }
            else
            {
                return kothies.status_code;
            }
        }



        public async Task<int> delete_kothi(int id)
         {
            var kothies = await _kothi.delete_kothi(id);
            return kothies;
        }
    }
}
