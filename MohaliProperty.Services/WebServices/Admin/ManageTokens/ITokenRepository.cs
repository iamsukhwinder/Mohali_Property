using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohali_Property_Model;

namespace MohaliProperty.Services.WebServices.Admin.ManageTokens
{
    public interface ITokenRepository
    {

        public Task<List<TokenVM>> gettokenlists();
        public Task<int> AddToken(TokenModel token);
        public Task<int> delete_token(int id);
    }
}
