using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mohali_Property_API.Modal;
using Mohali_Property_Model;

namespace Mohali_Property_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AdminController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetComopanyList")]
        public List<Company_profileVM> GetComopanyList()
        {

            var vm = _context.Company_profileVMs.FromSqlRaw("EXEC manage_company");

            if (vm == null)
            {
                return null;
            }
            else
            {
                return vm.ToList();
            }

        }


        [HttpPost("add_company")]
        public  Company_profile add_company(Company_profile obj) 
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                  new SqlParameter { ParameterName = "@company", Value = obj.company },
                  new SqlParameter { ParameterName = "@company_name", Value = obj.company_name },
                  new SqlParameter { ParameterName = "@email", Value = obj.email },
                  new SqlParameter { ParameterName = "@company_address", Value = obj.company_address },
                  new SqlParameter { ParameterName = "@city", Value = obj.city },
                  new SqlParameter { ParameterName = "@state", Value = obj.state },
                  new SqlParameter { ParameterName = "@pin_code", Value = obj.pin_code },
                  new SqlParameter { ParameterName = "@website", Value = obj.website},
                  new SqlParameter { ParameterName = "@gst_number", Value = obj.gst_number},
                  new SqlParameter { ParameterName = "@status", Value = obj.status},
                  new SqlParameter { ParameterName = "@mobile_number", Value = obj.mobile_number},
                  new SqlParameter { ParameterName = "@landline_number", Value = obj.landline_number},
                  new SqlParameter { ParameterName = "@company_logo", Value = obj.company_logo},


            };

            int n = _context.Database.ExecuteSqlRaw("EXEC add_company @company,@company_name,@email,@company_address,@city,@state,@pin_code,@website,@gst_number,@status,@mobile_number,@landline_number,@company_logo", parms.ToArray());


            return obj;

            
        }



    } 
}
