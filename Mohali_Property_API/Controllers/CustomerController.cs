using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mohali_Property_Model;
using MohaliProperty.Dbcontext.Models;
using MohaliProperty.Model;

namespace MohaliProperty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("customer_list")]
        public List<CustomerModel> customer_list()
        {

            var vm = _context.CustomerModels.FromSqlRaw("EXEC manage_customer");

            if (vm == null)
            {
                return null;
            }
            else
            {
                return vm.ToList();
            }

        }


        [HttpPost("add_customer")]
        public int add_customer(CustomerModel obj)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                  //new SqlParameter { ParameterName = "@customer_id", Value = obj.customer_id },
                  new SqlParameter { ParameterName = "@customer_name", Value = obj.customer_name },
                  new SqlParameter { ParameterName = "@parent_name", Value = obj.parent_name },
                  new SqlParameter { ParameterName = "@address", Value = obj.address },
                  new SqlParameter { ParameterName = "@city", Value = obj.city },
                  new SqlParameter { ParameterName = "@customer_email", Value = obj.customer_email },
                  new SqlParameter { ParameterName = "@mobile_number", Value = obj.mobile_number },
                  new SqlParameter { ParameterName = "@created_date", Value = obj.created_date},
                  


            };

            int n = _context.Database.ExecuteSqlRaw("EXEC add_customer @customer_name,@parent_name,@address,@city,@customer_email,@mobile_number,@created_date", parms.ToArray());

            if (n == 0)
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
