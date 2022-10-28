using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using TransparencyAuditPublic.Models;

namespace TransparencyAuditPublic
{
    public class ITransparencyAuditPublicServices:ITransparencyAuditPublic
    {
        TransparencyAuditPublicDataAccess DAO;
        public ITransparencyAuditPublicServices()
        {
            DAO = new TransparencyAuditPublicDataAccess();
        }

        //public List<MEmployee> GetAllEmployee()
        //{
        //    List<MEmployee> empList = new List<MEmployee>();
        //    DataTable dt = DAO.GetAllEmployee();
        //    if (dt != null)
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            //int SNo = 1;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                empList.Add(new MEmployee
        //                {
        //                    //SerialNo = SNo++,
        //                    Emp_ID = Convert.ToInt32(dr["Emp_ID"] ?? 0),
        //                    Emp_Name = Convert.ToString(dr["Emp_Name"]),
        //                    Emp_Email = Convert.ToString(dr["Emp_Email"]),
        //                    Emp_Mobile = Convert.ToInt64(dr["Emp_Mobile"]),
        //                    Emp_Address = Convert.ToString(dr["Emp_Address"]),
        //                    Emp_Gender = Convert.ToString(dr["Emp_Gender"]),
        //                    Emp_State = Convert.ToInt16(dr["Emp_State"]),
        //                    Emp_District = Convert.ToInt16(dr["Emp_District"]),
        //                    Dept_ID = Convert.ToInt16(dr["Dept_ID"]),
        //                });
        //            }
        //        }
        //    }
        //    return empList;
        //}


        //    public bool UpdateEmployee(MEmployee mEmp)
        //    {
        //        try
        //        {
        //            return DAO.UpdateEmployee(mEmp);
        //        }

        //        catch (Exception ex)
        //        {
        //            #region BL Execption
        //            if (ex.Message == "DAL")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text = ex.ToString();
        //                //ExceptionMethod.WriteLog(text);
        //                throw new Exception("BLL", ex);
        //            }
        //            #endregion

        //        }
        //    }
        //    public MEmployee EditEmployee(int ID)
        //    {
        //        try
        //        {
        //            MEmployee emp = new MEmployee();
        //            using (DataTable dt = DAO.GetEmployeeByID(ID))
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    emp.Emp_ID = Convert.ToInt32(dr["Emp_ID"] ?? 0);
        //                    emp.Emp_Name = Convert.ToString(dr["Emp_Name"]);
        //                    emp.Emp_Email = Convert.ToString(dr["Emp_Email"]);
        //                    emp.Emp_Mobile = Convert.ToInt64(dr["Emp_Mobile"]);
        //                    emp.Emp_Address = Convert.ToString(dr["Emp_Address"]);
        //                    emp.Emp_Gender = Convert.ToString(dr["Emp_Gender"]);
        //                    emp.Emp_State = Convert.ToInt16(dr["Emp_State"]);
        //                    emp.Emp_District = Convert.ToInt16(dr["Emp_District"]);
        //                    emp.Dept_ID = Convert.ToInt16(dr["Dept_ID"]);
        //                }
        //            }
        //            return emp;
        //        }

        //        catch (Exception ex)
        //        {
        //            #region BL Execption
        //            if (ex.Message == "DAL")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text = ex.ToString();
        //                //ExceptionMethod.WriteLog(text);
        //                throw new Exception("BLL", ex);
        //            }
        //            #endregion

        //        }
        //    }
        //    public bool DeleteEmployee(int ID)

        //    {
        //        try
        //        {
        //            return DAO.DeleteEmployee(ID);
        //        }
        //        catch (Exception ex)
        //        {
        //            #region BL Execption
        //            if (ex.Message == "DAL")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text = ex.ToString();
        //                //ExceptionMethod.WriteLog(text);
        //                throw new Exception("BLL", ex);
        //            }
        //            #endregion

        //        }
        //    }
        //    public List<SelectListItem> GetAllState()
        //    {
        //        try
        //        {
        //            List<SelectListItem> li = new List<SelectListItem>();
        //            li.Add(new SelectListItem() { Text = "--SELECT--", Value = "" });

        //            using (DataTable dt = DAO.GetAllState())
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    li.Add(new SelectListItem() { Text = Convert.ToString(dr["State_Name"]), Value = Convert.ToString(dr["State_Code"]) });

        //                }
        //            }
        //            return li;
        //        }
        //        catch (Exception ex)//exception this layer itself
        //        {
        //            if (ex.Message == "110001")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text1 = ex.ToString();
        //                //ExceptionMethod.WriteLog(text1);
        //                throw new Exception("210002", ex);
        //            }

        //        }
        //    }
        //    public List<SelectListItem> GetAllDistrictByStateCode(int State_Code)
        //    {
        //        try
        //        {
        //            List<SelectListItem> li = new List<SelectListItem>();
        //            li.Add(new SelectListItem() { Text = "--SELECT--", Value = "" });

        //            using (DataTable dt = DAO.GetAllDistrictByStateCode(State_Code))
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    li.Add(new SelectListItem() { Text = Convert.ToString(dr["District_Name"]), Value = Convert.ToString(dr["District_code"]) });

        //                }
        //            }
        //            return li;
        //        }
        //        catch (Exception ex)//exception this layer itself
        //        {
        //            if (ex.Message == "110001")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text1 = ex.ToString();
        //                //ExceptionMethod.WriteLog(text1);
        //                throw new Exception("210002", ex);
        //            }

        //        }
        //    }
        //    public List<SelectListItem> GetAllGender()
        //    {
        //        try
        //        {
        //            List<SelectListItem> li = new List<SelectListItem>();
        //            li.Add(new SelectListItem() { Value = "",Text = "--SELECT--"});

        //            using (DataTable dt = DAO.GetAllGender())
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    li.Add(new SelectListItem() { Value = Convert.ToString(dr["Gen_Code"]),Text = Convert.ToString(dr["Gen_Name"])});

        //                }
        //            }
        //            return li;
        //        }
        //        catch (Exception ex)//exception this layer itself
        //        {
        //            if (ex.Message == "110001")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text1 = ex.ToString();
        //                //ExceptionMethod.WriteLog(text1);
        //                throw new Exception("210002", ex);
        //            }

        //        }
        //    }
        //    public List<SelectListItem> GetAllDepartment()
        //    {
        //        try
        //        {
        //            List<SelectListItem> li = new List<SelectListItem>();
        //            li.Add(new SelectListItem() { Text = "--SELECT--", Value = "" });

        //            using (DataTable dt = DAO.GetAllDepartment())
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    li.Add(new SelectListItem() { Text = Convert.ToString(dr["Dept_Name"]), Value = Convert.ToString(dr["Dept_ID"]) });

        //                }
        //            }
        //            return li;
        //        }
        //        catch (Exception ex)//exception this layer itself
        //        {
        //            if (ex.Message == "110001")//Error data layer
        //            {
        //                string mess = ex.Message;
        //                throw new Exception(mess, ex);

        //            }
        //            else//Error on this layer itself
        //            {
        //                string text1 = ex.ToString();
        //                //ExceptionMethod.WriteLog(text1);
        //                throw new Exception("210002", ex);
        //            }

        //        }
        //    }

        public bool InsertHeadingData(HeadingModel mHeading)
        {
            try
            {
                return DAO.InsertHeadingData(mHeading);
            }

            catch (Exception ex)
            {
                #region BL Execption
                if (ex.Message == "DAL")//Error data layer
                {
                    string mess = ex.Message;
                    throw new Exception(mess, ex);

                }
                else//Error on this layer itself
                {
                    string text = ex.ToString();
                    //ExceptionMethod.WriteLog(text);
                    throw new Exception("BLL", ex);
                }
                #endregion

            }
        }
        public bool UpdateHeadingData(EditHeadingModel mHeading)
        {
            try
            {
                return DAO.UpdateHeadingData(mHeading);
            }

            catch (Exception ex)
            {
                #region BL Execption
                if (ex.Message == "DAL")//Error data layer
                {
                    string mess = ex.Message;
                    throw new Exception(mess, ex);

                }
                else//Error on this layer itself
                {
                    string text = ex.ToString();
                    //ExceptionMethod.WriteLog(text);
                    throw new Exception("BLL", ex);
                }
                #endregion

            }
        }
        public bool InsertUploadedFileData(UploadDetails mUploadDetails)
        {
            try
            {
                return DAO.InsertUploadedFileData(mUploadDetails);
            }

            catch (Exception ex)
            {
                #region BL Execption
                if (ex.Message == "DAL")//Error data layer
                {
                    string mess = ex.Message;
                    throw new Exception(mess, ex);

                }
                else//Error on this layer itself
                {
                    string text = ex.ToString();
                    //ExceptionMethod.WriteLog(text);
                    throw new Exception("BLL", ex);
                }
                #endregion

            }
        }
        public bool UpdateUploadedFileData(UploadDetails mUploadDetails)
        {
            try
            {
                return DAO.UpdateUploadedFileData(mUploadDetails);
            }

            catch (Exception ex)
            {
                #region BL Execption
                if (ex.Message == "DAL")//Error data layer
                {
                    string mess = ex.Message;
                    throw new Exception(mess, ex);

                }
                else//Error on this layer itself
                {
                    string text = ex.ToString();
                    //ExceptionMethod.WriteLog(text);
                    throw new Exception("BLL", ex);
                }
                #endregion

            }
        }
        public List<H1_CATEGORYMASTER> GetH1CATEGORYMASTERList()
        {
            List<H1_CATEGORYMASTER> h1_CATEGORYMASTER_LIST = new List<H1_CATEGORYMASTER>();
            DataTable dt = DAO.GetH1CATEGORYMASTERList();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //int SNo = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        h1_CATEGORYMASTER_LIST.Add(new H1_CATEGORYMASTER
                        {
                            //SerialNo = SNo++,
                            H1_ID = Convert.ToString(dr["H1_ID"] ?? 0),
                            H1_LINK = Convert.ToString(dr["H1_LINK"]),
                            H1_NAME = Convert.ToString(dr["H1_NAME"]),
                            H1_ISDELETE = Convert.ToString(dr["H1_ISDELETE"]),

                        });
                    }
                }
            }
            return h1_CATEGORYMASTER_LIST;
        }
        public List<H2_CATEGORYMASTER> GetH2CATEGORYMASTERList()
        {
            List<H2_CATEGORYMASTER> h2_CATEGORYMASTER_LIST = new List<H2_CATEGORYMASTER>();
            DataTable dt = DAO.GetH2CATEGORYMASTERList();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //int SNo = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        h2_CATEGORYMASTER_LIST.Add(new H2_CATEGORYMASTER
                        {
                            //SerialNo = SNo++,
                            H2_ID = Convert.ToString(dr["H2_ID"] ?? 0),
                            H2_LINK = Convert.ToString(dr["H2_LINK"]),
                            H2_NAME = Convert.ToString(dr["H2_NAME"]),
                            H1_ID = Convert.ToString(dr["H1_ID"]),
                            H1_LINK = Convert.ToString(dr["H1_LINK"]),
                            H2_ISDELETE = Convert.ToString(dr["H2_ISDELETE"])

                        });
                    }
                }
            }
            return h2_CATEGORYMASTER_LIST;
        }
        public List<H3_CATEGORYMASTER> GetH3CATEGORYMASTERList()
        {
            List<H3_CATEGORYMASTER> h3_CATEGORYMASTER_LIST = new List<H3_CATEGORYMASTER>();
            DataTable dt = DAO.GetH3CATEGORYMASTERList();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //int SNo = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        h3_CATEGORYMASTER_LIST.Add(new H3_CATEGORYMASTER
                        {
                            //SerialNo = SNo++,
                            H3_ID = Convert.ToString(dr["H3_ID"] ?? 0),
                            H3_LINK = Convert.ToString(dr["H3_LINK"]),
                            H3_NAME = Convert.ToString(dr["H3_NAME"]),
                            H1_ID = Convert.ToString(dr["H1_ID"]),
                            H2_ID = Convert.ToString(dr["H2_ID"]),
                            H1_LINK = Convert.ToString(dr["H1_LINK"]),
                            H2_LINK = Convert.ToString(dr["H2_LINK"]),
                            H3_ISDELETE = Convert.ToString(dr["H3_ISDELETE"])

                        });
                    }
                }
            }
            return h3_CATEGORYMASTER_LIST;
        }

        public bool Check_H3_LINK(string H3_LINK)
        {
            bool result = false;
            DataTable dt = DAO.Check_H3_LINK(H3_LINK);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        public HeadingModel GetH3_CATEGORYDETAILS(string H3_LINK)
        {
            HeadingModel headingModel = new HeadingModel();
            using (DataTable dt = DAO.GetH3_CATEGORYDETAILS(H3_LINK))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    headingModel.H3_GUID = Convert.ToString(dr["H3_GUID"] ?? 0);
                    headingModel.H3_CATEGORYDETAILS_ID = Convert.ToString(dr["H3_CATEGORYDETAILS_ID"]);
                    headingModel.H3_LINK = Convert.ToString(dr["H3_LINK"]);
                    headingModel.SUBJECT = Convert.ToString(dr["SUBJECT"]);
                    headingModel.TEXT = Convert.ToString(dr["TEXT"]);
                    headingModel.REMARKS = Convert.ToString(dr["REMARKS"]);
                    headingModel.H3_ID = Convert.ToString(dr["H3_ID"]);
                    headingModel.ISDELETE = Convert.ToString(dr["ISDELETE"]);
                    headingModel.HEADING_FileUpload = Convert.ToString(dr["HEADING_FileUpload"]);
                    headingModel.REMARKS_FileUpload = Convert.ToString(dr["REMARKS_FileUpload"]);
                }
            }
            return headingModel;
        }
        public List<UploadDetails> GetFILEUPLOADDETAILS(string H3_GUID)
        {
            List<UploadDetails> UploadDetails_LIST = new List<UploadDetails>();
            DataTable dt = DAO.GetFILEUPLOADDETAILS(H3_GUID);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //int SNo = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        UploadDetails_LIST.Add(new UploadDetails
                        {
                            //SerialNo = SNo++,
                            TITLE = Convert.ToString(dr["TITLE"] ?? 0),
                            PUBLISHDATE = Convert.ToString(dr["PUBLISHDATE"]),
                            HEADING = Convert.ToString(dr["HEADING"]),
                            REMARKS = Convert.ToString(dr["REMARKS"]),
                            FILENAME = Convert.ToString(dr["FILENAME"]),
                            FILEUPLOADDETAILS_ID = Convert.ToString(dr["FILEUPLOADDETAILS_ID"]),
                            SHOW_OR_NOT =Convert.ToBoolean(dr["SHOW_OR_NOT"])
                        });
                    }
                }
            }
            return UploadDetails_LIST;
        }
        public List<UploadDetails> GetFILEUPLOADDETAILS_SHOW(string H3_GUID)
        {
            List<UploadDetails> UploadDetails_LIST = new List<UploadDetails>();
            DataTable dt = DAO.GetFILEUPLOADDETAILS_SHOW(H3_GUID);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //int SNo = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        UploadDetails_LIST.Add(new UploadDetails
                        {
                            //SerialNo = SNo++,
                            TITLE = Convert.ToString(dr["TITLE"] ?? 0),
                            PUBLISHDATE = Convert.ToString(dr["PUBLISHDATE"]),
                            HEADING = Convert.ToString(dr["HEADING"]),
                            REMARKS = Convert.ToString(dr["REMARKS"]),
                            FILENAME = Convert.ToString(dr["FILENAME"]),
                            FILEUPLOADDETAILS_ID = Convert.ToString(dr["FILEUPLOADDETAILS_ID"]),
                            SHOW_OR_NOT = Convert.ToBoolean(dr["SHOW_OR_NOT"])
                        });
                    }
                }
            }
            return UploadDetails_LIST;
        }
    }
}
