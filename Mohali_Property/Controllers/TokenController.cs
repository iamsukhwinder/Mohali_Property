using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mohali_Property_Model;
using MohaliProperty.Services.WebServices.Admin.ManageCompany;
using MohaliProperty.Services.WebServices.Admin.ManageKothi;
using MohaliProperty.Services.WebServices.Admin.ManageTokens;

namespace Mohali_Property_Web.Controllers
{
    public class TokenController : Controller
    {
       
        private readonly ITokenRepository _tokenRepository;
        private readonly IManageKothi _kothi;
        private readonly ICompanyRepository _company;
        public TokenController(ITokenRepository tokenRepository, IManageKothi kothi, ICompanyRepository company)
        {
            _tokenRepository = tokenRepository;
            _kothi = kothi;
            _company = company;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult showtokens()
        {
            return PartialView("/Views/Admin/ManageTokens/All_tokens.cshtml");
        }

        public async Task<List<TokenVM>> GetTokenList()
        {
           var tokens  =await  _tokenRepository.gettokenlists();
            return tokens;

        }
        public async Task<IActionResult> addtokenview()
        {
            //for kothies drop down
            var kothies = await _kothi.getkothieslist();
            List<SelectListItem> kothiDD = new List<SelectListItem>();
            SelectListItem items1 = new SelectListItem();
            items1.Text = "---Select kothi---";
            items1.Value = "0";
            kothiDD.Add(items1);
            
            foreach (var kothie in kothies)
            {
                SelectListItem items = new SelectListItem();
                items.Text = kothie.kothi_Number.ToString();
                items.Value = kothie.kothi_id.ToString();
                kothiDD.Add(items);
            }
            ViewData["kothiesDD"] = kothiDD;

            //for company drop down
            var companies = await _company.GetComopanyList();
            List<SelectListItem> compnyDD = new List<SelectListItem>();
            SelectListItem items2 = new SelectListItem();
            items2.Text = "---Select company---";
            items2.Value = "0";
            compnyDD.Add(items2);
            foreach (var company in companies)
            {
                SelectListItem items3 = new SelectListItem();
                items3.Text = company.company_name;
                items3.Value = company.company_id.ToString();
                compnyDD.Add(items3);
            }
            ViewData["compnayDD"] = compnyDD;

            // for customer drop down
            var customers = await _company.GetComopanyList();
            List<SelectListItem> customerDD = new List<SelectListItem>();
            SelectListItem items4 = new SelectListItem();
            items4.Text = "---Select customer---";
            items4.Value = "0";
            customerDD.Add(items4);
            foreach (var customer in customers)
            {
                SelectListItem items5 = new SelectListItem();
                items5.Text = customer.company_name;
                items5.Value = customer.company_id.ToString();
                customerDD.Add(items5);
            }
            ViewData["customerDD"] = customerDD;

            DateTime date = DateTime.Today.AddDays(30);
            string check = date.Date.ToShortDateString();
            TempData["expiry_token_date"] = check;
            return PartialView("/Views/Admin/ManageTokens/Add_token.cshtml",kothies);
        }


        [HttpPost]
        public async Task<int> AddToken(TokenModel token)
        {
            DateTime today_date = DateTime.Today.Date;
            token.created_date = today_date;
            var result = await _tokenRepository.AddToken(token);
            return result;
        }

        [HttpGet]
        public async Task<int> delete_token(int id)
        {
            var result =await _tokenRepository.delete_token(id);

            return result;
        }
    }
}
