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
    }
}
