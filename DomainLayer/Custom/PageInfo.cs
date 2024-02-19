
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Custom
{
 
    public class PageInfo
    {
        public string SearchColumn { get; set; } = "Name";
        public string SearchValue { get; set; }
        public string OrderColumn { get; set; } = "Name";
        public bool OrderAsc { get; set; } = true;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int ItemNumber { get; set; }
        public List<int> PageSizeList { get; set; } = new() { 5, 10, 15, 20 };
        public string Controller { get; set; }
        
    }
}
