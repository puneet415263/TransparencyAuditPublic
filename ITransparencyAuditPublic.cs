using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TransparencyAuditPublic.Models;

namespace TransparencyAuditPublic
{
    public interface ITransparencyAuditPublic
    {
        //List<HeadingModel> GetAllEmployee();
        bool InsertHeadingData(HeadingModel mHeading);
        bool UpdateHeadingData(EditHeadingModel mHeading);
        bool InsertUploadedFileData(UploadDetails mUploadDetails);
        bool UpdateUploadedFileData(UploadDetails mUploadDetails);
        List<H1_CATEGORYMASTER> GetH1CATEGORYMASTERList();
        List<H2_CATEGORYMASTER> GetH2CATEGORYMASTERList();
        List<H3_CATEGORYMASTER> GetH3CATEGORYMASTERList();
        bool Check_H3_LINK(string H3_LINK);
        HeadingModel GetH3_CATEGORYDETAILS(string H3_LINK);
        List<UploadDetails> GetFILEUPLOADDETAILS(string H3_GUID);
        List<UploadDetails> GetFILEUPLOADDETAILS_SHOW(string H3_GUID);

    }
}
