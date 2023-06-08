using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mohali_Property_Model;
using MohaliProperty.Dbcontext.Models;

namespace MohaliProperty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookingApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getbookingdetail")]
        public ResponseModel<BookingModel> getbookingdetail(int id)
        {
            ResponseModel<BookingModel> res = new ResponseModel<BookingModel>();
            SqlParameter parm = new SqlParameter("@id", id);
            var bookingdetail = _context.bookings.FromSqlRaw("getbookingdetail @id",parm).ToList().FirstOrDefault();
            if(bookingdetail != null)
            {
                res.data = bookingdetail;
                res.message = "data collected succesfully";
                res.status_code = 200;
                res.is_success = true;
                return res;
            }
            else
            {
                res.data = bookingdetail;
                res.message = "data not found";
                res.status_code = 404;
                res.is_success = false;
                return res;
            }
        }
        [HttpPost("generate_token")]
        public ResponseModel<int> generate_token(TokenModel detail)
        {
            detail.created_date = DateTime.Now.Date;
            detail.expiry_date = DateTime.Now.Date.AddDays(30);
            List<SqlParameter> parms = new List<SqlParameter>
            {
                  new SqlParameter { ParameterName = "@customer_id", Value = detail.customer_id },
                  new SqlParameter { ParameterName = "@company_id", Value = detail.company_id },
                  new SqlParameter { ParameterName = "@kothi_id", Value = detail.kothi_id },
                  new SqlParameter { ParameterName = "@created_date", Value = detail.created_date },
                  new SqlParameter { ParameterName = "@expiry_date", Value = detail.expiry_date },

            };
            var result = _context.Database.ExecuteSqlRaw("genrate_token @customer_id,@company_id,@kothi_id,@created_date," +
                "@expiry_date", parms.ToArray());
            ResponseModel<int> res = new ResponseModel<int>();
            if(result == 0)
            {
                res.data = result;
                res.message = "something error";
                res.is_success = false;
                res.status_code = 403;
                return res;
            }
            else
            {
                res.data = result;
                res.message = "token generated";
                res.is_success = true;
                res.status_code = 200;
                return res;
            }
        }
    }
}
