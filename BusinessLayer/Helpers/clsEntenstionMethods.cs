using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    static internal class clsEntenstionMethods
    {
        //I can not use DataRow as input because we Treat with DataCell(Object) not the Row itself
        public static int? ToNullableInt32(this object value)
        {
            if (value == DBNull.Value || value == null)
                return null;
            return Convert.ToInt32(value);
        }
        public static int ToInt32(this object value)
            => value == DBNull.Value || value == null?default:
            Convert.ToInt32(value);
        public static decimal ToDecimal(this object value)
            => value == DBNull.Value || value == null ? default : 
            Convert.ToDecimal(value);
        public static bool ToBoolean(this object value)
            => value == DBNull.Value || value == null ? default :
            Convert.ToBoolean(value);
        public static DateTime ToDate(this object value)
           => Convert.ToDateTime(value);

        public static byte ToByte(this object value)
           => value == DBNull.Value || value == null ?
                default : Convert.ToByte(value);
        
        public static DateTime ToNullableDate(this object value)
            => value == DBNull.Value || value == null?default:
            Convert.ToDateTime(value);
    }

}
