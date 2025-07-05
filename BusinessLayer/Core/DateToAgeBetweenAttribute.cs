using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Core
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class DateToAgeBetweenAttribute:Attribute
    {
        public string ErrorMessage { get; set; }
        public byte Min {  get; set; }
        public byte Max { get; set; }
        public DateToAgeBetweenAttribute(byte Min,byte Max)
        {
            this.Min = Min;
            this.Max = Max;
        }
    }
}
