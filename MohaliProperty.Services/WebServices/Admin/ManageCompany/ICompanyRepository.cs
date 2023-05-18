using MohaliProperty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.ManageCompany
{
    public  interface ICompanyRepository
    {
        public Task<List<Company_profileVM>> GetComopanyList();
        public Task<int> add_company(Company_profileVM obj);
        public Task<Company_profileVM> Editcompany(int id);
        public Task<int> update_company(Company_profileVM obj);

        public Task<int> Deletecompany(int id);



    }
}
