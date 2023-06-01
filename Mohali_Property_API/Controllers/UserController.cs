using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mohali_Property_Model;
using MohaliProperty.Dbcontext;
using MohaliProperty.Dbcontext.Models;
using System.Security.Principal;

namespace MohaliProperty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetUserList")]
        public List<UserVM> GetUserList()
        {

            var vm = _context.userVMs.FromSqlRaw("EXEC manage_users");

            if (vm == null)
            {
                return null;
            }
            else
            {
                return vm.ToList();
            }

        }


        [HttpPost("add_user")]
        public int add_user(UserModel obj)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {

                  new SqlParameter { ParameterName = "@name", Value = obj.name },
                  new SqlParameter { ParameterName = "@email", Value = obj.email },
                  new SqlParameter { ParameterName = "@address", Value = obj.address },
                  new SqlParameter { ParameterName = "@city", Value = obj.city },
                  new SqlParameter { ParameterName = "@state", Value = obj.state },
                  new SqlParameter { ParameterName = "@pin_code", Value = obj.pin_code },
                 new SqlParameter { ParameterName = "@mobile_Number", Value = obj.mobile_number},
                 new SqlParameter { ParameterName = "@status", Value = "Active"},
                new SqlParameter { ParameterName = "@role_id", Value =2},
                new SqlParameter { ParameterName = "@username", Value = obj.email},
                new SqlParameter { ParameterName = "@password", Value = obj.mobile_number}



            };

            int n = _context.Database.ExecuteSqlRaw("EXEC manage_User @name,@email,@address,@city,@state,@role_id,@pin_code,@mobile_number,@status,@username,@password", parms.ToArray());


            if (n == 0)
            {
                return 0;
            }
            else
            {
                return 1;

            }


        }

        [HttpPost("Edit")]
        public async Task<int> Edit(int id)
        {
            SqlParameter parm = new SqlParameter("@id",id);
            var vm = _context.userVMs.FromSqlRaw("EXEC Edit @id", parm).ToList().FirstOrDefault();
            return  0;
        }


        [HttpPost("Update")]
        public UserVM Update(UserVM obj)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
              new SqlParameter { ParameterName = "@id", Value = obj.id },
                new SqlParameter { ParameterName = "@name", Value = obj.name },
                new SqlParameter { ParameterName = "@email", Value = obj.email },
                new SqlParameter { ParameterName = "@mobile_Number", Value = obj.mobile_number },

                    };
            var n = _context.Database.ExecuteSqlRaw("Updatedata @id, @name,@email,@mobile_number", parms.ToArray());
            return obj;
        }




        [HttpPost("Delete")]
        public  UserVM Delete(UserVM dlt)
        {
            SqlParameter parm = new SqlParameter("@id", dlt.id);
            var vm = _context.Database.ExecuteSqlRaw("EXEC dltuser @id", parm);
            return dlt;
        }


    }

}

