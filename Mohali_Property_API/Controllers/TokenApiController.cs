using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Mohali_Property_Model;
using MohaliProperty.Dbcontext.Models;

namespace Mohali_Property_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TokenApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("gettokenlist")]

        public List<TokenVM> gettokenlist()
        {
            var tokens = _context.tokenVMs.FromSqlRaw("manage_kothi_tokens").ToList();
            return tokens;
        }

        [HttpPost("add_token")]
        public int add_token(TokenModel token)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                  new SqlParameter { ParameterName = "@kothi_id", Value = token.kothi_id},
                  new SqlParameter { ParameterName = "@company_id", Value = token.company_id },
                  new SqlParameter { ParameterName = "@customer_id", Value = token.customer_id },
                  new SqlParameter { ParameterName = "@created_date", Value = token.created_date },
                  new SqlParameter { ParameterName = "@expiry_date", Value = token.expiry_date },
                  

             };
            var result = _context.Database.ExecuteSqlRaw("create_token @kothi_id,@company_id,@customer_id,@created_date,@expiry_date", parms.ToArray());
            
            if(result == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        [HttpGet("delete_token")]
        public int delete_token(int id)
        {
            SqlParameter parm = new SqlParameter("@id", id);
            var result = _context.Database.ExecuteSqlRaw("delete_token @id",parm);
            if(result == 0)
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
