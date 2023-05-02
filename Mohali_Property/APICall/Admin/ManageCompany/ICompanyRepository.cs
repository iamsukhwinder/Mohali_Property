using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;

namespace Mohali_Property_Web.APICall.Admin.ManageCompany
{
    public interface ICompanyRepository
    {

        public Task<List<Company_profileVM>> GetComopanyList();
        public Task<Company_profile> add_company(Company_profile obj);
       

    }
}
