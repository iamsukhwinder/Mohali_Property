
using Mohali_Property_Model;

namespace Mohali_Property_Web.APICall.Login
{
    public interface ILoginRepository
    {
        public Task<LoginVM> Login(LoginModel obj);

    }
}
