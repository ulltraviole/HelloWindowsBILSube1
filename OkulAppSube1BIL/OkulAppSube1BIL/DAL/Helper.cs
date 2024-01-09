using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class Helper
    {
        // BEGIN Singleton Pattern BEGIN //
        private Helper() { }
        private static Helper _helper;
        public static Helper CreateAsSingleton()
        {
            if (_helper == null)
            {
                _helper = new Helper();
            }
            return _helper;
        }
        // END Singleton Pattern END //
        SqlConnection cn;
        SqlCommand cmd;
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                using (cn = new SqlConnection(cstr))
                {
                    using (cmd = new SqlCommand(cmdtext, cn))
                    {
                        if (p != null)
                        {
                            cmd.Parameters.AddRange(p);
                        }
                        cn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Dispose();
                cmd.Dispose();
                throw ex;
            }
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                using (cn = new SqlConnection(cstr))
                {
                    using (cmd = new SqlCommand(cmdtext, cn))
                    {

                        if (p != null)
                        {
                            cmd.Parameters.AddRange(p);
                        }
                        cn.Open();
                        return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Dispose();
                cmd.Dispose();
                throw ex;
            }
        }
    }
}

