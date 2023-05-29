using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohali_Property_Model
{
    public class ResponseModel<T>
    {
        public T data { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
        public bool is_success { get; set; }
    }
}
