
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDBManager
    {
        //We use (using) not Generic variables for all methods for Thread safety and We here Treat with 1 DB Type (SqlServer)
        string AppConfigCN = clsDataAccessSettings.CN;
        string TriggerSP = "sp_set_session_context";
        public object ExecuteScalar(string spName)
        {
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                {
                    CN.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.LogError(ex);
                return null;
            }
        }
        public Object ExecuteScalar(string spName,Dictionary<string,object>map)
        {
        
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                {
                    CN.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (KeyValuePair<string, object> kvp in map)
                    {
                        if (!(kvp.Key == "@key" || kvp.Key == "@value" || kvp.Key == "@read_only"))
                            cmd.Parameters?.AddWithValue(kvp.Key, kvp.Value ?? DBNull.Value);
                    }
                    if(map.ContainsKey("@key")&&map.ContainsKey("@value")&&map.ContainsKey("@read_only"))
                    {
                        using (SqlCommand setContextCmd = new SqlCommand(TriggerSP, CN))
                        {
                            setContextCmd.CommandType = CommandType.StoredProcedure;
                            setContextCmd.Parameters?.AddWithValue("@key", map["@key"] ?? DBNull.Value);
                            setContextCmd.Parameters?.AddWithValue("@value", map["@value"] ?? DBNull.Value);
                            setContextCmd.Parameters?.AddWithValue("@read_only", map["@read_only"] ?? DBNull.Value);
                            setContextCmd.ExecuteNonQuery();
                        }
                    }
                   

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.LogError(ex);
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
                    CN.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.LogError(ex);
                return false;
            }
        }
        public bool ExecuteNonQuery(string spName, Dictionary<string, object> map)
        {
           
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                {
                    CN.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (KeyValuePair<string, object> kvp in map)
                    {
                        if (!(kvp.Key == "@key" || kvp.Key == "@value" || kvp.Key == "@read_only"))
                            cmd.Parameters?.AddWithValue(kvp.Key, kvp.Value ?? DBNull.Value);
                    }
                    if (map.ContainsKey("@key") && map.ContainsKey("@value") && map.ContainsKey("@read_only"))
                    {
                        using (SqlCommand setContextCmd = new SqlCommand(TriggerSP, CN))
                        {
                            setContextCmd.CommandType = CommandType.StoredProcedure;
                            setContextCmd.Parameters?.AddWithValue("@key", map["@key"] ?? DBNull.Value);
                            setContextCmd.Parameters?.AddWithValue("@value", map["@value"] ?? DBNull.Value);
                            setContextCmd.Parameters?.AddWithValue("@read_only", map["@read_only"] ?? DBNull.Value);
                            setContextCmd.ExecuteNonQuery();
                        }
                    }


                    return cmd.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.LogError(ex);
                return false;
            }
        }
        //Disconnected Mode (Data Adapter)
        public DataTable ExecuteDataTable(string spName)
        {
            
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                using (SqlDataAdapter DA = new SqlDataAdapter())
                {
                    CN.Open();
                    DataTable DT = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Do not Use Parameterized ctor
                    DA.SelectCommand = cmd;
                    DA.Fill(DT);
                    return DT ?? new DataTable();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.LogError(ex);
                return new DataTable();
            }
        }
        public DataTable ExecuteDataTable(string spName, Dictionary<string, object> map)
        {
             
            try
            {
                using (SqlConnection CN = new SqlConnection(AppConfigCN))
                using (SqlCommand cmd = new SqlCommand(spName, CN))
                using (SqlDataAdapter DA = new SqlDataAdapter())
             
                {
                    CN.Open();
                    DataTable DT = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (KeyValuePair<string, object> kvp in map)
                        cmd.Parameters?.AddWithValue(kvp.Key, kvp.Value ?? DBNull.Value);
                    //Do not Use Parameterized ctor
                    DA.SelectCommand = cmd;
                    DA.Fill(DT);
                    return DT ?? new DataTable();
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.LogError(ex);
                return new DataTable();
            }
        }
    }
}
