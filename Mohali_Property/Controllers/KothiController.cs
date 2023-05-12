using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;
using Mohali_Property_Web.APICall.Admin.ManageCompany;
using Mohali_Property_Web.APICall.Admin.ManageKothi;

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
        public async Task<int> Add_kothi(KothiModel kothiModel)
        {

            var data = await _kothi.Add_Kothi(kothiModel);
            if (data == null)
            {
                return 0;
            }
            else
            {
                return 1;
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
            return kothies;
        }



        public async Task<int> delete_kothi(int id)
         {
            var kothies = await _kothi.delete_kothi(id);
            return kothies;
        }
    }
}
