using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Model
{
    public class Company_profileVM
    {

        [Key]
        public int company_id { get; set; }

        [Required(ErrorMessage = "Company is Required"), StringLength(30)]

        public string company { get; set; }

        [Required(ErrorMessage = "Company Name is Required"), StringLength(30)]
        public string company_name { get; set; }

        [Required(ErrorMessage = "Company Address is Required"), StringLength(200)]
        public string company_address { get; set; }

        [Required(ErrorMessage = "City is Required"), StringLength(30)]
        public string city { get; set; }

        [Required(ErrorMessage = "State is Required"), StringLength(30)]
        public string state { get; set; }

        [Required, StringLength(30)]
        public string pin_code { get; set; }

        [Required, StringLength(30)]
        public string website { get; set; }

        [Required(ErrorMessage = "Invalid GST Number.")]
        //[RegularExpression(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", ErrorMessage = "Invalid GST Number.")]
        public string gst_number { get; set; }

        [Required(ErrorMessage = "Status is Required!")]
        public string status { get; set; }
        //[Display(Name = "Image")]
        [Required(ErrorMessage = "Pick an Image")]
        //[FileExtensions(Extensions = "jpg,jpeg,png")]
        public string company_logo { get; set; }

        //[Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        //           ErrorMessage = "Entered phone format is not valid.")]
        public string mobileNumber { get; set; }
        //[Display(Name = "LandLine Number ")]
        [Required(ErrorMessage = "LandLine Number Required!")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        //           ErrorMessage = "Entered LandLine Number format is not valid.")]
        public string landlineNo { get; set; }

        [Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

    }
}
