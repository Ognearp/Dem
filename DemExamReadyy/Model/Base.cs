using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExamReadyy.Model
{
    public class Base
    {

        public object GetProperty(string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                return this.GetType().GetProperty(property).GetValue(this);
            }
            return null;
        }
       
    }
}
