
using System.Data;
using System.Data.Common;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Infrastructure
{
    internal class clsDBManager
    {
        //We use (using) not Generic variables for all methods for Thread safety and We here Treat with 1 DB Type (SqlServer)
        string AppConfigCN = clsDataAccessSettings.CN;
        string SessionContextSP = "sp_set_session_context";
        bool IsSessionContextParameter(SqlParameter param)
            => param.ParameterName == "@key" ||
               param.ParameterName == "@value" ||
               param.ParameterName == "@read_only";



        public object ExecuteScalar(string spName)
        {
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                {
                    CN?.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    return cmd?.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WindowsEventLog?.Log(ex);
                return null;
            }
        }
        public object ExecuteScalar(string spName, HashSet<SqlParameter>Parameters)
        {

            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                using (SqlCommand setContextCmd = new SqlCommand(SessionContextSP, CN))
                {
                    CN?.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    setContextCmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameters)
                    {
                        if (IsSessionContextParameter(param))
                            setContextCmd?.Parameters?.Add(param);
                        else
                            cmd?.Parameters?.Add(param);        
                    }

                    if (setContextCmd?.Parameters.Count > 0)
                    {
                        if (setContextCmd?.ExecuteNonQuery() == 0)
                            throw new Exception("Context Session SP Error.");
                    }
                    return cmd?.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WindowsEventLog?.Log(ex);
                return null;
            }
        }
        
        public bool ExecuteNonQuery(string spName)
        {
            try
            {

                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                {
                    CN?.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd?.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WindowsEventLog?.Log(ex);
                return false;
            }
        }
        public bool ExecuteNonQuery(string spName, HashSet<SqlParameter> Parameters)
        {

            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                using (SqlCommand setContextCmd = new SqlCommand(SessionContextSP, CN))
                {
                    CN?.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    setContextCmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameters)
                    {
                        if (IsSessionContextParameter(param))
                            setContextCmd?.Parameters?.Add(param);
                        else
                            cmd?.Parameters?.Add(param);
                    }

                    if (setContextCmd?.Parameters.Count > 0)
                    {
                        if (setContextCmd?.ExecuteNonQuery() == 0)
                            throw new Exception("Context Session SP Error.");
                    }
                    return cmd?.ExecuteNonQuery()>0;
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WindowsEventLog?.Log(ex);
                return false;
            }
        }
         
        //Disconnected Mode (Data Adapter)
        public DataTable ExecuteDataTable(string spName)
        {
            DataTable DT = new DataTable();
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                using (SqlDataAdapter DA = new SqlDataAdapter())
                {
                    CN?.Open();
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Do not Use Parameterized ctor
                    DA.SelectCommand = cmd;
                    DA?.Fill(DT);
                    return DT ?? new DataTable();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WindowsEventLog?.Log(ex);
                return DT;
            }
        }
   
         
        public DataTable ExecuteDataTable(string spName, HashSet<SqlParameter> Parameters)
        {
            DataTable DT=new DataTable();
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                using (SqlCommand setContextCmd = new SqlCommand(SessionContextSP, CN))
                using (SqlDataAdapter DA=new SqlDataAdapter())
                {
                    CN?.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    setContextCmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameters)
                    {
                        if (IsSessionContextParameter(param))
                            setContextCmd?.Parameters?.Add(param);
                        else
                            cmd?.Parameters?.Add(param);
                    }
                    if(setContextCmd?.Parameters.Count>0)
                    {
                        if (setContextCmd?.ExecuteNonQuery() == 0)
                            throw new Exception("Context Session SP Error.");
                    }
                    DA.SelectCommand = cmd;
                    DA?.Fill(DT);
                    return DT ?? new DataTable();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WindowsEventLog?.Log(ex);
                return DT;
            }
        }
    }
}
