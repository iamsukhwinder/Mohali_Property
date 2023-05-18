using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Model
{
    public class Company_profileVM
    {
       public int  company_id { get; set; }
        public string company { get; set; } 
        public string company_name { get; set; }
        public string company_address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pin_code { get; set; }
        public string website { get; set; }
        public string gst_number { get; set; }
        public string status { get; set; }
        public string company_logo { get; set; }
        public string mobileNumber { get; set; }
        public string landlineNo { get; set; }
        public string email { get; set; }
   
    }
}
