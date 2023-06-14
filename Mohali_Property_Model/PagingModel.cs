using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohaliProperty.Model;

namespace Mohali_Property_Model
{
    public class PagingModel
    {
        public List<KothiModel> kothies {  get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
