using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TransparencyAuditPublic.Models;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace TransparencyAuditPublic
{
    public class TransparencyAuditPublicDataAccess
    {
        //public DataTable GetAllEmployee()

        //{
        //    try
        //    {
        //        return SqlDBHelper.ExecuteSelectCommand(GlobalDB.SPS_GetAllEmployee, CommandType.StoredProcedure);
        //    }
        //    catch (Exception ex)//exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        //ExceptionMethod.WriteLog(text);
        //        throw new Exception("110001", ex);
        //    }
        //}

        //public DataTable GetEmployeeByID(int ID)

        //{
        //    try
        //    {
        //        SqlParameter[] parforInsert = new SqlParameter[]{
        //        new SqlParameter("@ID",ID)

        //    };
        //        return SqlDBHelper.ExecuteParamerizedSelectCommand(GlobalDB.SPS_GetEmployeeByID, CommandType.StoredProcedure, parforInsert);
        //    }
        //    catch (Exception ex)//exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        //ExceptionMethod.WriteLog(text);
        //        throw new Exception("110001", ex);
        //    }
        //}



        //public bool UpdateEmployee(MEmployee mEmp)
        //{
        //    try
        //    {
        //        SqlParameter[] parforInsert = new SqlParameter[]{
        //        new SqlParameter("@Emp_ID",mEmp.Emp_ID),
        //        new SqlParameter("@Emp_Name",mEmp.Emp_Name),
        //        new SqlParameter("@Emp_Email",mEmp.Emp_Email),
        //        new SqlParameter("@Emp_Mobile",mEmp.Emp_Mobile),
        //        new SqlParameter("@Emp_Gender",mEmp.Emp_Gender),
        //        new SqlParameter("@Emp_Address",mEmp.Emp_Address),
        //        new SqlParameter("@Emp_State",mEmp.Emp_State),
        //        new SqlParameter("@Emp_District",mEmp.Emp_District),
        //        new SqlParameter("@Dept_ID",mEmp.Dept_ID)

        //    };
        //        return SqlDBHelper.ExecuteNonQuery(GlobalDB.SPU_UpdateEmployeeByID, CommandType.StoredProcedure, parforInsert);
        //    }
        //    catch (Exception ex) //exception this layer itself
        //    {
        //        string text = ex.ToString();
        //       // ExceptionMethod.WriteLog(text);
        //        throw new Exception("DAL", ex);
        //    }
        //}

        //public bool DeleteEmployee(int ID)
        //{
        //    try
        //    {
        //        SqlParameter[] parforInsert = new SqlParameter[]{
        //        new SqlParameter("@Emp_ID",ID)

        //    };
        //        return SqlDBHelper.ExecuteNonQuery(GlobalDB.SPD_DeleteEmployeeByID, CommandType.StoredProcedure, parforInsert);
        //    }
        //    catch (Exception ex) //exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        //ExceptionMethod.WriteLog(text);
        //        throw new Exception("DAL", ex);
        //    }
        //}

        //public DataTable GetAllGender()
        //{
        //    try
        //    {
        //        SqlParameter[] par = new SqlParameter[]{
        //   };
        //        DataTable dt = SqlDBHelper.ExecuteSelectCommand(GlobalDB.SPS_GetAllGender, CommandType.StoredProcedure);
        //        return dt;
        //    }
        //    catch (Exception ex)//exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        //ExceptionMethod.WriteLog(text);
        //        throw new Exception("110001", ex);

        //    }

        //}
        //public DataTable GetAllDepartment()
        //{
        //    try
        //    {
        //        SqlParameter[] par = new SqlParameter[]{
        //   };
        //        DataTable dt = SqlDBHelper.ExecuteSelectCommand(GlobalDB.SPS_GetAllDepartment, CommandType.StoredProcedure);
        //        return dt;
        //    }
        //    catch (Exception ex)//exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        //ExceptionMethod.WriteLog(text);
        //        throw new Exception("110001", ex);

        //    }

        //}
        //public DataTable GetAllState()
        //{
        //    try
        //    {
        //        SqlParameter[] par = new SqlParameter[]{
        //   };
        //        DataTable dt = SqlDBHelper.ExecuteSelectCommand(GlobalDB.SPS_GetAllState, CommandType.StoredProcedure);
        //        return dt;
        //    }
        //    catch (Exception ex)//exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        //ExceptionMethod.WriteLog(text);
        //        throw new Exception("110001", ex);

        //    }

        //}
        //public DataTable GetAllDistrictByStateCode(int State_Code)
        //{
        //    try
        //    {
        //        SqlParameter[] par = new SqlParameter[]{
        //           new SqlParameter("@State_Code",State_Code)
        //   };
        //        DataTable dt = SqlDBHelper.ExecuteParamerizedSelectCommand(GlobalDB.SPS_GetAllDistrictByStateCode, CommandType.StoredProcedure, par);
        //        return dt;
        //    }
        //    catch (Exception ex)//exception this layer itself
        //    {
        //        string text = ex.ToString();
        //        // ExceptionMethod.WriteLog(text);
        //        throw new Exception("110001", ex);

        //    }

        //}


        public bool InsertHeadingData(HeadingModel mHeading)
        {
            try
            {
                OracleParameter[] parforInsert = new OracleParameter[]{
                new OracleParameter("P_H3_GUID",mHeading.H3_GUID),
                new OracleParameter("P_H3_LINK",mHeading.H3_LINK),
                new OracleParameter("P_SUBJECT",mHeading.SUBJECT),
                new OracleParameter("P_TEXT",mHeading.TEXT),
                new OracleParameter("P_REMARKS",mHeading.REMARKS),
                new OracleParameter("P_H3_ID",mHeading.hdn_H3_ID)

            };
                return OracleDBHelper.ExecuteNonQuery(GlobalDB.SPI_AddH3_CATEGORYDETAILS, CommandType.StoredProcedure, parforInsert);
            }
            catch (Exception ex) //exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("DAL", ex);
            }
        }
        public bool UpdateHeadingData(EditHeadingModel mHeading)
        {
            try
            {
                OracleParameter[] parforInsert = new OracleParameter[]{
                    new OracleParameter("P_H3_CATEGORYDETAILS_ID",mHeading.hdn_H3_CATEGORYDETAILS_ID),
                    new OracleParameter("P_H3_GUID",mHeading.hdn_H3_GUID),
                    new OracleParameter("P_H3_LINK",mHeading.hdn_H3_LINK),
                    new OracleParameter("P_H3_ID",mHeading.hdn_H3_ID),
                    new OracleParameter("P_SUBJECT",mHeading.SUBJECT),
                    new OracleParameter("P_TEXT",mHeading.TEXT),
                    new OracleParameter("P_REMARKS",mHeading.REMARKS)
                    
            };
                return OracleDBHelper.ExecuteNonQuery(GlobalDB.SPU_UpdateH3_CATEGORYDETAILS, CommandType.StoredProcedure, parforInsert);
            }
            catch (Exception ex) //exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("DAL", ex);
            }
        }
        public bool InsertUploadedFileData(UploadDetails mUploadDetails)
        {
            try
            {
                OracleParameter[] parforInsert = new OracleParameter[]{
                new OracleParameter("P_TITLE",mUploadDetails.TITLE),
                new OracleParameter("P_FILENAME",mUploadDetails.FILENAME),
                new OracleParameter("P_FILESIZE",mUploadDetails.FILESIZE),
                new OracleParameter("P_FILEPATH",mUploadDetails.FILEPATH),
                new OracleParameter("P_PUBLISHDATE",mUploadDetails.PUBLISHDATE),
                //new OracleParameter("P_H3_CATEGORYDETAILS_ID",1),
                new OracleParameter("P_H3_GUID",mUploadDetails.H3_GUID),
                new OracleParameter("P_HEADING",mUploadDetails.HEADING),
                new OracleParameter("P_REMARKS",mUploadDetails.REMARKS),
                new OracleParameter("P_SHOW_OR_NOT",Convert.ToInt16(mUploadDetails.SHOW_OR_NOT))
                //,new OracleParameter("P_UPDATED_ON",System.DateTime.Now)

            };
                return OracleDBHelper.ExecuteNonQuery(GlobalDB.SPI_AddFILEUPLOADDETAILS, CommandType.StoredProcedure, parforInsert);
            }
            catch (Exception ex) //exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("DAL", ex);
            }
        }
        public bool UpdateUploadedFileData(UploadDetails mUploadDetails)
        {
            try
            {
                OracleParameter[] parforInsert = new OracleParameter[]{
                    new OracleParameter("P_FILEUPLOADDETAILS_ID",mUploadDetails.FILEUPLOADDETAILS_ID),
                    new OracleParameter("P_TITLE",mUploadDetails.TITLE),
                    new OracleParameter("P_PUBLISHDATE",mUploadDetails.PUBLISHDATE),
                    new OracleParameter("P_HEADING",mUploadDetails.HEADING),
                    new OracleParameter("P_REMARKS",mUploadDetails.REMARKS),
                    new OracleParameter("P_SHOW_OR_NOT",Convert.ToInt16(mUploadDetails.SHOW_OR_NOT))
                    //new OracleParameter("P_H3_GUID",mUploadDetails.H3_GUID),
                    //new OracleParameter("P_FILENAME",mUploadDetails.FILENAME),
                    //new OracleParameter("P_FILESIZE",mUploadDetails.FILESIZE),
                    //new OracleParameter("P_FILEPATH",mUploadDetails.FILEPATH),
                    //,new OracleParameter("P_UPDATED_ON",System.DateTime.Now)

            };
                return OracleDBHelper.ExecuteNonQuery(GlobalDB.SPU_UpdateFILEUPLOADDETAILS, CommandType.StoredProcedure, parforInsert);
            }
            catch (Exception ex) //exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("DAL", ex);
            }
        }
        public DataTable GetH1CATEGORYMASTERList()
        {
            try
            {
                OracleParameter[] param = { };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_GetH1CATEGORYMASTERList, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }

        public DataTable GetH2CATEGORYMASTERList()
        {
            try
            {
                OracleParameter[] param = { };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_GetH2CATEGORYMASTERList, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }
        public DataTable GetH3CATEGORYMASTERList()
        {
            try
            {
                OracleParameter[] param = { };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_GetH3CATEGORYMASTERList, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }
        public DataTable Check_H3_LINK( string H3_LINK)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[]{
                new OracleParameter("P_H3_LINK",H3_LINK),
            };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_Check_H3_LINK, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }
        public DataTable GetH3_CATEGORYDETAILS(string H3_LINK)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[]{
                new OracleParameter("P_H3_LINK",H3_LINK),
            };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_Check_H3_LINK, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }
        public DataTable GetFILEUPLOADDETAILS(string H3_GUID)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[]{
                new OracleParameter("P_H3_GUID",H3_GUID),
            };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_GetFILEUPLOADDETAILS, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }
        public DataTable GetFILEUPLOADDETAILS_SHOW(string H3_GUID)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[]{
                new OracleParameter("P_H3_GUID",H3_GUID),
            };
                return OracleDBHelper.ExecuteDataSet(GlobalDB.SPS_GetFILEUPLOADDETAILS_SHOW, param);
            }
            catch (Exception ex)//exception this layer itself
            {
                string text = ex.ToString();
                //ExceptionMethod.WriteLog(text);
                throw new Exception("110001", ex);
            }
        }
    }
}
