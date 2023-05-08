using Microsoft.AspNetCore.Mvc;
using Mohali_Property_Model;

namespace Mohali_Property_Web.APICall.Admin.ManageCompany
{
    public interface ICompanyRepository
    {

        public Task<List<Company_profileVM>> GetComopanyList();
        public Task<int> add_company(Company_profileVM obj);
        public Task<Company_profileVM> Editcompany(int id);
        public Task<int> update_company(Company_profileVM obj);

    }
}
