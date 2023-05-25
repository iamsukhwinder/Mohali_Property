using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public  class CustomerModel
    {
        public int customer_id { get; set; }
        //public int company_id { get; set; }
        public string customer_name { get; set; }
        public string parent_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string customer_email { get; set; }
        public string mobile_number { get; set; }
        public DateTime created_date { get; set; }
    }
}
