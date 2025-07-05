using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers
{
    static internal class clsEntenstionMethods
    {
        //I can not use DataRow as input because we Treat with DataCell(Object) not the Row itself
        //You can not directly convert object to nullable int... compile time error, so you must check null manually then cast the result to int?
        public static int? ToNullableInt32(this object value)
        {
            //null != DBNull
            //null is when DB does not return any result
            //DBNull is when DB return the value (NULL) with an existed Row result
            if (value == DBNull.Value || value == null)
                return null;
            return Convert.ToInt32(value);
        }
        public static byte? ToNullableByte(this object value)
        {
            if (value == DBNull.Value || value == null)
                return null;
            return Convert.ToByte(value);
        }
        public static bool ToBoolean(this object value)
        {
            if (value == DBNull.Value || value == null)
                return false;
            return Convert.ToBoolean(value);
        }
        public static void AddLoggedUserID(this HashSet<SqlParameter> Parameters,int LoggedUserID)
        {
            Parameters?.Add(new SqlParameter("@key", "LoggedUserID"));
            Parameters?.Add(new SqlParameter("@value", LoggedUserID));
            Parameters?.Add(new SqlParameter("@read_only", false));
        }
        public static void AddSQLParameter(this HashSet<SqlParameter> Parameters
            , string Key,object Value,bool IsInput=true)
        {
            SqlParameter param=new SqlParameter(Key, Value);
            param.Direction = IsInput ? ParameterDirection.Input : ParameterDirection.Output;
            Parameters?.Add(param);
        }

        public static int? ToNullableInt64(this object value)
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
