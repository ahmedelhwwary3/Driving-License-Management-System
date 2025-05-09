using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static class clsEntenstionMethods
    {
        //I can not use DataRow as input because we Treat with DataCell(Object) not the Row itself
        //You can not directly convert object to nullable int... compile time error, so you must check null manually then cast the result to int?
        public static int? ToNullableInt(this Object value)
        {
            //null != DBNull
            //null is when DB does not return any result
            //DBNull is when DB return the value (NULL) with an existed Row result
            if (value == DBNull.Value || value == null)
                return (int?)null;
            return Convert.ToInt32(value);
        }
        public static Boolean ToBoolean(this Object value)
        {
            if (value == DBNull.Value || value == null)
                return false;
            return Convert.ToBoolean(value);
        }
        public static void AddLoggedUserID(this Dictionary<string,Object>map,int LoggedUserID)
        {
            map?.Add("@key", "LoggedUserID");
            map?.Add("@value", LoggedUserID);
            map?.Add("@read_only", false);
        }
        public static int? ToNullableInt32(this Object value)
        {
            if (value == DBNull.Value || value == null)
                return null;
            return Convert.ToInt32(value);
        }
 

        public static int? ToNullableInt64(this Object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            return Convert.ToInt32(value);
        }

        //Must add T with ? ... to tell the compiler i know that the object can be null
        public static T? GetByNullableID<T>(this Func<int?, T> GetMethod, int? ID) where T : class
            => ID.HasValue ? GetMethod(ID.Value) : null;
    


    }
}
