
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mohali_Property_Model;
using MohaliProperty.Dbcontext.Models;
using MohaliProperty.Model;

namespace Mohali_Property_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LoginController (ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("Login")]
        public LoginVM Login(LoginVM obj)
        {
      

			List<SqlParameter> parm = new List<SqlParameter>
			{
				  new SqlParameter { ParameterName = "@username", Value = obj.username},
				  new SqlParameter { ParameterName = "@password", Value = obj.password },
				 

			};

			
			var data = _context.LoginVMs.FromSqlRaw("check_login @username,@password", parm.ToArray()).ToList().FirstOrDefault();
            if(data == null)
            {
                return null;
            }
            else
            {
                return data;
            }
        }

        [HttpGet("updatepassword")]
        public ResponseModel<int> updatepassword(string username,string password)
        {
            ResponseModel<int> res = new ResponseModel<int>();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@email", Value = username},
                new SqlParameter {ParameterName = "@password", Value = password},

            };
            var result = _context.Database.ExecuteSqlRaw("update_password @email,@password", parm.ToArray());
            if(result != 0)
            {
                res.data = result;
                res.is_success = true;
                res.message = "Password updated";
                res.status_code = 200;
                return res;
            }
            else
            {
                res.data = result;
                res.is_success = false;
                res.message = "No User Exist Please Check your email id";
                res.status_code = 403;
                return res;
            }
        }

        [HttpGet("checkuserbyemail")]
        public ResponseModel<int> checkuserbyemail(string email)
        {
            ResponseModel<int> res = new ResponseModel<int>();
            SqlParameter parm = new SqlParameter("@email", email);
            var result = _context.users.FromSqlRaw("checkuserbyemail @email", parm).ToList().FirstOrDefault();
            if (result != null)
            {
                res.data = 1;
                res.is_success = true;
                res.message = "User Exist";
                res.status_code = 200;
                return res;
            }
            else
            {
                res.data = 0;
                res.is_success = false;
                res.message = "No User Exist Please Check your email id";
                res.status_code = 403;
                return res;
            }
        }


    }
}
