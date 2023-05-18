using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.Login
{
    public interface ILoginRepository
    {
        public Task<LoginVM> Login(LoginModel obj);

    }
}
