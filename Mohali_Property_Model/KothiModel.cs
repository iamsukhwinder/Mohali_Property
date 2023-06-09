﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Model
{
    public  class KothiModel
    {
        [Key]


       
        public int? kothi_id { get; set; }


        [Required(ErrorMessage = "Kothi Number is Required")]
        public int? kothi_Number { get; set; }


        [Required(ErrorMessage = "Kothi Block is Required")]
        public string block { get; set; }

        [Required(ErrorMessage = " Kothi Size required")]
        public double? kothi_size { get; set; }

        [Required(ErrorMessage = "Kothi Description is Required")]
        public string kothi_description { get; set; }

        // [Required(ErrorMessage = "Dimension is Required"), Range(3, 30)]

        [Required(ErrorMessage = "Dimension is Required")]
        public string dimension { get; set; }


        [Required(ErrorMessage = "Plot Area is required.")]
        public double? plot_area { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public double? price { get; set; }




        [Required(ErrorMessage = "BHK is Required!")]
        public int? bhk { get; set; }



        [Required(ErrorMessage = "Booking Amount is required.")]

        //[Range(0.0, 100.0, ErrorMessage = "The Value field must be between 0.0 and 100.0.")]

        //[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The Booking Amount field must be a valid decimal number with up to 2 decimal places.")]

        public double? booking_amount { get; set; }



        [Required(ErrorMessage = "Status is Required")]
        public string status { get; set; }

        // [Required(ErrorMessage = "Please select an image.")]
        //[DataType(DataType.Upload)]
        //[FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Please upload an image file (JPG, JPEG, or PNG).")]

        //[Required(ErrorMessage = "Kothi Image is Required")]
        public string kothi_image { get; set; }

        public int hold { get; set; }

        [Required(ErrorMessage = "Company is Required")]
        public int company_id { get; set; }

    }
}
