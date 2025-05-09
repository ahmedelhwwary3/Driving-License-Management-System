using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Global
{
    public class clsFormat
    {
        public static string DateToShortString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }



    }
}
