using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public class TokenModel
    {
        [Key]
        public int token_id { get; set; }
        public int kothi_id { get; set; }
        public int company_id { get; set; }
        public int customer_id { get; set; }
        public DateTime created_date { get; set; }
        public DateTime expiry_date { get; set; }

    }
}
