using Mohali_Property_Model;

namespace Mohali_Property_Web.APICall.Admin.ManageToken
{
    public interface ITokenRepository
    {
        public Task<List<TokenVM>> gettokenlists();
    }
}
