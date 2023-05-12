using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mohali_Property_API.Modal;
using Mohali_Property_Model;

namespace Mohali_Property_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenApiController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TokenApiController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("gettokenlist")]

        public List<TokenVM> gettokenlist()
        {
            var tokens = _context.tokenVMs.FromSqlRaw("manage_kothi_tokens").ToList();
            return tokens;
        }
    }
}
