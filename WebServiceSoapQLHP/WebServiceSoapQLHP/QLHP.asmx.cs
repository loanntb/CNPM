using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceSoapQLHP
{
    /// <summary>
    /// Summary description for QLHP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QLHP : System.Web.Services.WebService
    {
        LinqHocPhiDataContext db = null;
        public QLHP()
        {
            db = new LinqHocPhiDataContext();
        }
        [WebMethod]
        public List<Sinh_vien> DanhsachSV()
        {
            List<Sinh_vien> ListSt = db.Sinh_viens.ToList();
            foreach (Sinh_vien p in ListSt)
                p.ToString();
            return ListSt;
        }
    }
}
