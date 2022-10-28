using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TransparencyAuditPublic.Models;

namespace TransparencyAuditPublic.Controllers
{
    public class TransparencyAuditPublicController : Controller
    {
        private ITransparencyAuditPublic interfaceobj;
        public TransparencyAuditPublicController()
                : this(new ITransparencyAuditPublicServices())
        {
        }

        public TransparencyAuditPublicController(ITransparencyAuditPublic interobj)
        {
            interfaceobj = interobj;

        }
        // GET: TransparencyAudit
        [HttpGet]
        public ActionResult HeadingIndexListPublic()
        {
            HeadingIndexList headingIndexList = new HeadingIndexList();
            headingIndexList.H1_CATEGORYMASTER_List = interfaceobj.GetH1CATEGORYMASTERList();
            headingIndexList.H2_CATEGORYMASTER_List = interfaceobj.GetH2CATEGORYMASTERList();
            headingIndexList.H3_CATEGORYMASTER_List = interfaceobj.GetH3CATEGORYMASTERList();
            return View(headingIndexList);
        }
        [HttpGet]
        public ActionResult ViewHeadingPublic(string H3_LINK,string H3_ID,string H3_NAME)
        {
            ViewHeadingModel viewHeadingModel = new ViewHeadingModel();
            var getH3_CATEGORYDETAILS = interfaceobj.GetH3_CATEGORYDETAILS(H3_LINK);
            var getFILEUPLOADDETAILS=new List<UploadDetails>();
            if (getH3_CATEGORYDETAILS.H3_GUID!=null)
            {
                getFILEUPLOADDETAILS = interfaceobj.GetFILEUPLOADDETAILS_SHOW(getH3_CATEGORYDETAILS.H3_GUID);
            } 
            if (getH3_CATEGORYDETAILS.H3_LINK != null && getH3_CATEGORYDETAILS.H3_GUID!=null && getFILEUPLOADDETAILS.Count != 0)
            {
                var ViewHeading = new ViewHeadingModel
                {
                    hdn_H3_CATEGORYDETAILS_ID = getH3_CATEGORYDETAILS.H3_CATEGORYDETAILS_ID,
                    hdn_H3_GUID = getH3_CATEGORYDETAILS.H3_GUID,
                    hdn_H3_LINK = getH3_CATEGORYDETAILS.H3_LINK,
                    hdn_H3_ID = getH3_CATEGORYDETAILS.H3_ID,
                    H3_CATEGORYDETAILS_ID = getH3_CATEGORYDETAILS.H3_CATEGORYDETAILS_ID,
                    H3_GUID = getH3_CATEGORYDETAILS.H3_GUID,
                    H3_LINK = getH3_CATEGORYDETAILS.H3_LINK,
                    TEXT = getH3_CATEGORYDETAILS.TEXT,
                    REMARKS = getH3_CATEGORYDETAILS.REMARKS,
                    SUBJECT = getH3_CATEGORYDETAILS.SUBJECT,
                    HEADING_FileUpload = getH3_CATEGORYDETAILS.HEADING_FileUpload,
                    REMARKS_FileUpload = getH3_CATEGORYDETAILS.REMARKS_FileUpload,
                    UploadDetailsList = getFILEUPLOADDETAILS

                };
                viewHeadingModel = ViewHeading;
            }
            else
            {
                var ViewHeading = new ViewHeadingModel
                {
                    H3_LINK = H3_LINK,
                    SUBJECT = H3_NAME
                };
                viewHeadingModel = ViewHeading;
            }
            return View(viewHeadingModel);
        }

        public ActionResult DownloadFile(string FILENAME)
        {
            byte[] filedata = null;
            string contentType = "";
            try
            {
                //string uploadsFolder = Server.MapPath("~/UploadFiles/");
                string uploadsFolder = OracleDBHelper.UploadFilePath;
                string path = Path.Combine(uploadsFolder, FILENAME);
                filedata = System.IO.File.ReadAllBytes(HttpUtility.HtmlEncode(path));
                contentType = "application/octet-stream";
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = FILENAME,
                    Inline = true,
                };
                Response.Headers.Add("Content-Disposition", cd.ToString());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
            return File(filedata, contentType);
        }
        
    }
}