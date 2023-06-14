using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.BuilderProperties;
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

            int n = _context.Database.ExecuteSqlRaw("EXEC add_Users @name,@address,@city,@state,@role_id,@pin_code,@mobile_number,@email,@status,@username,@password", parms.ToArray());


            if (n == 0)
            {
                return 0;
            }
            else
            {
                return 1;

            }


        }

        [HttpGet("edit_user")]
        public async Task<UserVM> edit_user(int id)
        {
            SqlParameter parm = new SqlParameter("@id",id);
            var vm = _context.userVMs.FromSqlRaw("EXEC Edituser @id", parm).ToList().FirstOrDefault();
            return  vm;
        }


        [HttpPost("Update")]
        public ResponseModel<int> Update(UserVM obj)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
              new SqlParameter { ParameterName = "@id", Value = obj.id },
                new SqlParameter { ParameterName = "@name", Value = obj.name },
                new SqlParameter { ParameterName = "@email", Value = obj.email },
                new SqlParameter { ParameterName = "@mobile_Number", Value = obj.mobile_number },
               new SqlParameter { ParameterName = "@address ", Value=obj.address },
               new SqlParameter { ParameterName = "@state", Value=obj.state },
                new SqlParameter { ParameterName = "@pin_code", Value=obj.pin_code },


                    };
            var n = _context.Database.ExecuteSqlRaw("UpdateUser @id,@name,@email,@mobile_number,@address,@state,@pin_code", parms.ToArray());
            ResponseModel<int> res = new ResponseModel<int>();

            if (n == 0)
            {
                res.data = n;
                res.message = "failed to update";
                res.is_success = false;
                res.status_code = 402;
                return res;
            }
            else
            {
                res.data = n;
                res.message = "Kothi details Updated";
                res.is_success = true;
                res.status_code = 200;
                return res;
            }

        }





        [HttpGet("Delete")]
        public int Delete(int id)
        {
            SqlParameter parm = new SqlParameter("@id", id);
            var vm = _context.Database.ExecuteSqlRaw(" dltuser @id", parm);
            if (vm == 0)
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

