using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public  class AddKothi
    {
        public int kothi_id { get; set; }
        public int kothi_Number { get; set; }
        public string dimension { get; set; }
        public string kothi_unit { get; set;}

        public string block { get; set; }
        public string kothi_size { get; set; }
        public float unit_rate { get; set; }
        public float price { get; set; }
        public float booking_amount { get; set; }
        public string status { get; set; }
        public float token_amount { get; set; }

    }
}
