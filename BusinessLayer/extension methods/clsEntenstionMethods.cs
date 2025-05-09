using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer 
{
    static class clsEntenstionMethods
    {
        //I can not use DataRow as input because we Treat with DataCell(Object) not the Row itself
        public static int? ToNullableInt32(this Object value)
        {
            if (value == DBNull.Value || value == null)
                return null;
            return Convert.ToInt32(value);
        }
        public static decimal ToDecimal(this Object value)
        {
            if (value == DBNull.Value || value == null)
                return 0;
            return Convert.ToDecimal(value);
        }
        public static decimal? ToNullableDecimal(this Object value)
        {
            if (value == DBNull.Value || value == null)
                return null;
            return Convert.ToDecimal(value);
        }
        public static DateTime ToDate(this Object value)
        {
            if (value == null || value == DBNull.Value)
                return DateTime.Now;
            return Convert.ToDateTime(value);
        }
 
        public static int? ToNullableInt64(this Object value)
        {
            if(value==null || value == DBNull.Value)
                return null;
            return Convert.ToInt32(value);
        }
 
        //Must add T with ? ... to tell the compiler i know that the object can be null
        public static T? GetByNullableID<T>(this Func<int?, T> GetMethod, int? ID) where T : class
            => ID.HasValue ? GetMethod(ID.Value) : null;
        public static T? GetByNullableID<T>(this Func<long?, T> GetMethod, long? ID) where T : class
            => ID.HasValue ? GetMethod(ID.Value) : null;
        public static Boolean ToBoolean(this Object value)
        {
            if (value == DBNull.Value || value == null)
                return false;
            return Convert.ToBoolean(value);
        }
    }
}
