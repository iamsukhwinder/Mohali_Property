using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public class BookingModel
    {
        public int kothi_id { get; set; }   
        public int kothi_Number { get; set; }
        public double kothi_size { get; set; }

        public double plot_area { get; set; }
        public string dimension { get; set; }
        public double price { get; set; }
        public double booking_amount { get; set; }
        public int bhk { get; set; }
        public int hold { get; set; }
        public int? customer_id { get; set; }
        //public string  name { get; set; }
        //public string mobile_Number { get; set; }
        //public string address { get; set; }
        public int company_id { get; set; } 
        public string company_name { get; set; }
        public string company_address { get; set; }


    }
}
