using Mohali_Property_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Services.WebServices.Admin.ManageUser
{
    public interface IUserRepository
    {
        public Task<List<UserVM>> GetUserList();
        public Task<int> add_user(UserModel obj);
    }
}
