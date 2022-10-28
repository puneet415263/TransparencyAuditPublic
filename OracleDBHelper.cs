using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace TransparencyAuditPublic
{
    public class OracleDBHelper
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        public static string UploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"].ToString();
        public static DataSet Execute_DSSPQuery(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            DataSet Ds = new DataSet();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);
                    cmd.CommandTimeout = 300;

                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(Ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return Ds;
        }
        //public static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        //{
        //    DataTable table = null;
        //    using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
        //    {
        //        using (SqlCommand cmd = con.CreateCommand())
        //        {
        //            cmd.CommandType = cmdType;
        //            cmd.CommandText = CommandName;
        //            cmd.CommandTimeout = 300;
        //            try
        //            {
        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    table = new DataTable();
        //                    da.Fill(table);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }



        //        }
        //    }

        //    return table;
        //}
        public static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);
                    cmd.CommandTimeout = 300;
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return table;
        }
        // its function return inserted id
        public static int ExecuteScalar(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);
                    cmd.CommandTimeout = 300;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        result = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {

                        con.Close();
                    }
                }
            }

            return (result);
        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        //[Obsolete]
        //public static bool ExecuteNonQuery(string CommandName, CommandType cmdType, OracleParameter[] pars)
        //{
        //    int result = 0;

        //    using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
        //    {
        //        using (OracleCommand cmd = new OracleCommand(CommandName, con))
        //        {
        //            cmd.CommandType = cmdType;
        //            //cmd.CommandText = CommandName;
        //            cmd.Parameters.AddRange(pars);
        //            //cmd.CommandTimeout = 300;
        //            try
        //            {
        //                if (con.State != ConnectionState.Open)
        //                {
        //                    con.Open();
        //                }

        //                result = cmd.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {

        //                con.Close();
        //            }
        //        }
        //    }
        //    return (result >= 0);
        //}

        public static bool ExecuteNonQuery(string CommandName, CommandType cmdType, OracleParameter[] pars)
        {
            DataSet ds = new DataSet();
            int rowcount = 0;
            using (OracleConnection oc = new OracleConnection(CONNECTION_STRING))
            {
                using (OracleCommand cmd = new OracleCommand(CommandName, oc))
                {
                    oc.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(pars);
                    rowcount = cmd.ExecuteNonQuery();
                    oc.Close();
                }
            }
            if (rowcount > -2)
                return true;
            else
                return false;

        }
        public static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (OracleConnection oc = new OracleConnection(CONNECTION_STRING))
            {
                using (OracleCommand cmd = new OracleCommand(CommandName, oc))
                {
                    oc.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    try
                    {
                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        oc.Close();
                    }
                }
            }
            return table;
        }

        public static DataTable ExecuteDataSet(string ProcName, OracleParameter[] param)
        {
            DataTable dt = new DataTable();
            using (OracleConnection oc = new OracleConnection(CONNECTION_STRING))
            {
                OracleCommand cmd = new OracleCommand(ProcName, oc);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(dt);
            }
            return dt;
        }
    }
}
