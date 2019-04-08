using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Template1.Controllers
{
    public class NganhController : ApiController
    {
        QLHPDataContext db = null;
        public NganhController()
        {
            db = new QLHPDataContext();
        }
        // sửa ngành học
        [HttpPut]
        public bool SuaThongTinNganhHoc(string Ma_Nganh, string Ten_Nganh)
        {
            try
            {
                Nganh nganh = db.Nganhs.Single(d => d.Ma_Nganh == Ma_Nganh);
                nganh.Ten_Nganh = Ten_Nganh;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Thêm ngành học
        [HttpPost]
        public bool ThemNganhHoc(string Ma_Nganh, string Ten_Nganh)
        {
            try
            {
                Nganh nganh = new Nganh();
                nganh.Ma_Nganh = Ma_Nganh;
                nganh.Ten_Nganh = Ten_Nganh;
                db.Nganhs.InsertOnSubmit(nganh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa Ngành Học
        [HttpDelete]
        public bool XoaNganhHoc(string Ma_Nganh)
        {
            try
            {
                Nganh nganh = db.Nganhs.Single(d => d.Ma_Nganh == Ma_Nganh);
                db.Nganhs.DeleteOnSubmit(nganh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Danh sách thống kê số tiền nộp theo ngành đã nạp
        [HttpGet]
        public List<V_TongTienTheoNganh> TongTienHocPhiDaNapTheoNganh()
        {
            List<V_TongTienTheoNganh> listDS = db.V_TongTienTheoNganhs.ToList();
            foreach (V_TongTienTheoNganh p in listDS)
                p.ToString();
            return listDS;
        }
        // Danh sách thống kê số tiền nộp theo ngành tra cứu
        [HttpGet]
        public List<V_TongTienTheoNganh> TongTienHocPhiDaNapTheoTenNganh(string tenNganh)
        {
            List<V_TongTienTheoNganh> listDS = db.V_TongTienTheoNganhs.Where(x => x.Ten_Nganh == tenNganh).ToList();
            foreach (V_TongTienTheoNganh p in listDS)
                p.ToString();
            return listDS;
        }

    }
}
