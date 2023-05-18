
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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


        

        
    }
}
