using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public class TokenVM
    {
        public int token_id { get; set; }
        public int kothi_Number { get; set; }
        public string kothi_size { get; set; }  
        public string customer_name { get; set; }
        public string mobile_number { get; set; }
        public string price { get; set; }
        public double booking_amount { get; set; }
        public double recieved_ammount {  get; set; }

    }
}
