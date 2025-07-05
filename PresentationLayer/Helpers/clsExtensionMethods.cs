using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Global
{
    public static class clsExtensionMethods
    {
        public static byte? ToNullableByte(this Object value)
        {
            return (value == DBNull.Value || value == null) ?
                null : Convert.ToByte(value);
        }
        public static bool ToBoolean(this Object value)
        {
            return (value == DBNull.Value || value == null) ?
                false : Convert.ToBoolean(value);
        }
    }
}
