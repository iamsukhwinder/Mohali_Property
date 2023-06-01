using Mohali_Property_Model;
using MohaliProperty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.ManageCustomer
{
    public interface IManageCustomer
    {
        public Task<List<CustomerModel>> getcustomerlist();
        public Task<int> AddCustomer(CustomerModel obj);
        public Task<CustomerModel> EditCustomer(int id);
        public Task<int> UpdateCustomer(CustomerModel obj);
        public Task<int> Deletecustomer(int id);

    }
}
