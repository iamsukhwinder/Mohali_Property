using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Model
{
    public class LoginVM
    {
        
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string mobile_number { get; set; }
        public string status { get; set; }

    }
}
