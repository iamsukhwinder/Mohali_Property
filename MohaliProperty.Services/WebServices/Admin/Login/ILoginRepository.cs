using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohali_Property_Model;
using MohaliProperty.Model;

namespace MohaliProperty.Services.WebServices.Admin.Login
{
    public interface ILoginRepository
    {
        public Task<LoginVM> Login(LoginModel obj);
        public Task<ResponseModel<int>> updatepassword(LoginModel logdetail);
        public Task<ResponseModel<int>> checkuserbyemail(string email);

    }
}
