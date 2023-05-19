using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Model
{
    public class LoginModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 5)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Range(0, 15, ErrorMessage = "Can only be between 0 .. 15")]
        [StringLength(2, ErrorMessage = "Max 2 digits")]

        public int role_id { get; set; }

        [Range(0, 15, ErrorMessage = "Can only be between 0 .. 15")]
        [StringLength(2, ErrorMessage = "Max 2 digits")]
        public int user_id { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, MinimumLength = 5)]
        public string status { get; set; }
    }
}
