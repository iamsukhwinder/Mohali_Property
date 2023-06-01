using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.BuilderProperties;
using Mohali_Property_Model;
using MohaliProperty.Dbcontext.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MohaliProperty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SignUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public int signup(UserModel obj) 
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                  new SqlParameter { ParameterName = "@name", Value = obj.name},
                  new SqlParameter { ParameterName = "@email", Value = obj.email },
                  new SqlParameter { ParameterName = "@address", Value = obj.address },
                  new SqlParameter { ParameterName = "@state", Value = obj.state },
                  new SqlParameter { ParameterName = "@city", Value = obj.city },
                  new SqlParameter { ParameterName = "@pin_code", Value = obj.pin_code },
                  new SqlParameter { ParameterName = "@mobile_number", Value = obj.mobile_number },
                  new SqlParameter { ParameterName = "@status", Value = "Active"},
                  new SqlParameter { ParameterName = "@role_id", Value =2}



            };


            var data = _context.Database.ExecuteSqlRaw("EXEC SignUp @name,@email,@address,@state,@city,@pin_code,@mobile_number,@status,@role_id", parms.ToArray());
            if (data == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}
