using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransparencyAuditPublic.Models
{
    public class HeadingModel
    {
        public string hdn_H3_ID { get; set; }
        public string H3_GUID { get; set; }
        public string H3_CATEGORYDETAILS_ID { get; set; }
        public string H3_LINK { get; set; }
        public string SUBJECT { get; set; }
        public string TEXT { get; set; }
        public string REMARKS { get; set; }
        public string H3_ID { get; set; }
        public string ISDELETE { get; set; }
        public List<UploadDetails> UploadDetailsList { get; set; }
        public string HEADING_FileUpload { get; set; }
        public string REMARKS_FileUpload { get; set; }

    }
    public class UploadDetails
    {
        public string FILEUPLOADDETAILS_ID { get; set; }
        public string HEADING { get; set; }
        public string REMARKS { get; set; }
        public string TITLE { get; set; }
        public string FILENAME { get; set; }
        public string FILESIZE { get; set; }  
        public string FILEPATH { get; set; }
        public string PUBLISHDATE { get; set; }
        public string H3_CATEGORYDETAILS_ID { get; set; }
        public string H3_GUID { get; set; }
        public bool SHOW_OR_NOT { get; set; }
        public string UPDATED_ON { get; set; }
        public string ISDELETE { get; set; }

    }
    public class HeadingIndexList
    {
        public List<H1_CATEGORYMASTER> H1_CATEGORYMASTER_List { get; set; }
        public List<H2_CATEGORYMASTER > H2_CATEGORYMASTER_List { get; set; }
        public List<H3_CATEGORYMASTER> H3_CATEGORYMASTER_List { get; set; }
    }
    public class H1_CATEGORYMASTER
    {
        public string H1_ID { get; set; }
        public string H1_LINK { get; set; }
        public string H1_NAME { get; set; }
        public string H1_ISDELETE { get; set; }
    }
    public class H2_CATEGORYMASTER
    {
        public string H2_ID { get; set; }
        public string H2_LINK { get; set; }
        public string H2_NAME { get; set; }
        public string H1_ID { get; set; }
        public string H1_LINK { get; set; }
        public string H2_ISDELETE { get; set; }
    }
    public class H3_CATEGORYMASTER
    {
        public string H3_ID { get; set; }
        public string H3_LINK { get; set; }
        public string H3_NAME { get; set; }
        public string H1_ID { get; set; }
        public string H2_ID { get; set; }
        public string H1_LINK { get; set; }
        public string H2_LINK { get; set; }
        public string H3_ISDELETE { get; set; }
    }
}

//public class AUDIT_ITEM
//{
//    public string PAGE_ID { get; set; }
//    public int SEQ1 { get; set; }
//    public int SEQ2 { get; set; }
//    public int SEQ3 { get; set; }
//    public string TITLE { get; set; }
//    public int IS_ACTIVE { get; set; }
//}

//@foreach(var item in ViewBag.auditlist)
//                                {
//    if (item.SEQ2 == 0)
//    {
//                                        < div class= "pl-0" >< b class= "pr-2" > @item.SEQ1 </ b >< b > @item.TITLE </ b ></ div >
//                                    }
//                                    else if (item.SEQ3 == 0)
//{
//                                        < div class= "pl-2" >< b class= "pr-2" > @item.SEQ1.@item.SEQ2 </ b >< b > @item.TITLE </ b ></ div >
//                                    }
//                                    else
//{
//                                        < div class= "pl-4" >< b class= "pr-2" > @item.SEQ1.@item.SEQ2.@item.SEQ3 </ b >< a href = "@Url.Action("Edit ","TransparencyAudit ", new {pageid = @item.PAGE_ID})" > @item.TITLE </ a ></ div >
//                                    }
//                                }