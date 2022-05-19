using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExamReadyy.OtherClass
{
    public class SortItem
    {
        public string Title { get; set; }
        public string Property { get; set; }
        public SortItem(string property, string title)
        {
            Property = property;
            Title = title;
        }
    }
}
