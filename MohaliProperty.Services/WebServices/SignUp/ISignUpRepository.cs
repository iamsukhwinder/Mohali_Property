using Mohali_Property_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.SignUp
{
    public interface ISignUpRepository
    {
        public Task<int> signup(CustomerModel obj);
    }
}
