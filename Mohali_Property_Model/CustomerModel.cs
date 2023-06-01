using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public  class CustomerModel
    {

        [Key]
        public int customer_id { get; set; }

        [Required(ErrorMessage = "Customer Name is Required"), Range(3, 50)]
        public string customer_name { get; set; }

        [Required(ErrorMessage = "Parent Name is Required")]
        public string parent_name { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string address { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string city { get; set; }

        [Required(ErrorMessage = "Customer Email is Required")]
        public string customer_email { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        public string mobile_number { get; set; }

        [Required(ErrorMessage = "Created Date is Required")]
        public DateTime created_date { get; set; }
    }
}
