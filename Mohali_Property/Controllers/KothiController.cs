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

        [HttpGet]
        public IActionResult add_kothi_view()
        {
            var check = PartialView("/Views/Admin/ManageKothi/Add_Kothi.cshtml");
            return check;
        }

        [HttpPost]
        public async Task<int> Add_kothi(IFormCollection kothidata)
        {

            if (kothidata.Files.Count >= 2)
            {
                return 301;
            }
            if (kothidata.Files[0].ContentType != "image/jpeg" && kothidata.Files[0].ContentType != "image/png" && kothidata.Files[0].ContentType != "image/jpg")
            {
                return 300;
            }
            if (kothidata.Files.Count != 0)
            {
                var file = kothidata.Files[0];
                var size = file.Length;
                int kothi_Number = Convert.ToInt32( kothidata["kothi_Number"]);
                string block = kothidata["block"];
                double kothi_size = Convert.ToDouble( kothidata["kothi_size"]);
                string kothi_description = kothidata["kothi_description"]; 
                string dimension = kothidata["dimension"];
                double plot_area = Convert.ToDouble (kothidata["plot_area"]);
                double price = Convert.ToDouble(kothidata["price"]);
                int bhk = Convert.ToInt32( kothidata["bhk"]);
                double booking_amount = Convert.ToDouble(kothidata["booking_amount"]);
                string status = kothidata["status"];
                int hold = Convert.ToInt32 (kothidata["1"]);
                string kothi_image = kothidata.Files["0"].FileName;

                var webPath = _hostingEnvironment.WebRootPath;
                var filePath = Path.Combine(webPath, "Image/kothi_images");
                filePath = Path.Combine(filePath, file.FileName + kothi_Number);
                KothiModel kothi = new KothiModel();
                kothi.kothi_Number = kothi_Number;
                kothi.block = block;
                kothi.kothi_size = kothi_size;
                kothi.kothi_description = kothi_description;
                kothi.dimension = dimension;
                kothi.plot_area = plot_area;
                kothi.price = price;
                kothi.bhk = bhk;
                kothi.booking_amount = booking_amount;
                kothi.status = status;
                //kothi.kothi_image = kothi_image;
                kothi.hold = 1;

                var result = await _kothi.Add_Kothi(kothi);
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


        public IActionResult showkothies()
        {
            return PartialView("/Views/Admin/ManageKothi/All_kothies.cshtml");
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
                   return PartialView("/Views/Admin/ManageKothi/Edit_kothi.cshtml",kothies);
          

        }


        [HttpPost]
        public async Task<int> update_kothi(KothiModel obj)
        {
            var kothies = await _kothi.update_kothi(obj);
            if (kothies == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }



        public async Task<int> delete_kothi(int id)
         {
            var kothies = await _kothi.delete_kothi(id);
            return kothies;
        }
    }
}
