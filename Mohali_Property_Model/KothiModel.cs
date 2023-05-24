using System;
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
        public int kothi_id { get; set; }
        public int kothi_Number { get; set; }

        public string block { get; set; }
        public double kothi_size { get; set; }
        public string kothi_description { get; set; }
        public string dimension { get; set; }
        public double plot_area { get; set; }

        //public string kothi_unit { get; set;}
        //public double unit_rate { get; set; }
        public double price { get; set; }
        public int bhk { get; set; }
        public double booking_amount { get; set; }
        public string status { get; set; }
        //public double token_amount { get; set; }
       // public string kothi_image { get; set; }
        public int hold { get; set; }

    }
}
