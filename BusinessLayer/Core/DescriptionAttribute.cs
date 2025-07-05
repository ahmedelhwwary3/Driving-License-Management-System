using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Core
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true)]
    public class DescriptionAttribute:Attribute
    {
        public string Text { get; set; }
        public DescriptionAttribute(string text)
            => this.Text = text;


    }
}
