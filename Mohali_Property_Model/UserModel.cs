using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mohali_Property_Model
{
    public class UserModel
    {
        [Key]

        public int id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string name { get; set; }

        

        [Required(ErrorMessage = "Address is Required")]
        public string address { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string city { get; set; }

        [Required(ErrorMessage = "State is Required")] 

        public string state { get; set; }

        [Required(ErrorMessage = "Pincode is Required")]
        public string pin_code { get; set; }

       
        [Required(ErrorMessage = "Phone Number Required!")]
        

        public string mobile_number { get; set; }



        [Required(ErrorMessage = "Email is  Required!")]
        public string email { get; set; }

        public int login_id { get; set; }
        //[Required, StringLength(30)]

        //public string status { get; set; }



    }
}

  