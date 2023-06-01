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

        //[Required(ErrorMessage = "name is Required"), Range(3, 50)]
        public string name { get; set; }

        

        //[Required(ErrorMessage = "Address is Required"), Range(3, 100)]
        public string address { get; set; }

        //[Required(ErrorMessage = "City is Required"), Range(3, 30)]
        public string city { get; set; }

        //[Required, /*StringLength*/(30)]
        public string state { get; set; }

        //[Required, /*StringLength*/(30)]
        public string pin_code { get; set; }

        //[Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Phone Number Required!")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        //           ErrorMessage = "Entered phone format is not valid.")]

        public string mobile_number { get; set; }

        

        //[Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]

        public string email { get; set; }

        //[Required, StringLength(30)]

        //public string status { get; set; }



    }
}

  