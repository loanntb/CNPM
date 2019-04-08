using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Template1.Controllers
{
    public class LopController : ApiController
    {
        QLHPDataContext db = null;
        public LopController()
        {
            db = new QLHPDataContext();
        }
        [HttpPost]
        public bool ThemLop(string Ten_Lop, string Ma_Nganh)
        {
            try
            {
                Lop lop = new Lop();
                lop.Ten_Lop = Ten_Lop;
                lop.Ma_Nganh = Ma_Nganh;
                db.Lops.InsertOnSubmit(lop);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Sửa lớp học
        [HttpPut]
        public bool SuaThongTinLop(string Ma_Lop, string Ten_lop, string Ma_Nganh)
        {
            try
            {
                Lop lop = db.Lops.Single(d => d.Ma_Lop == Ma_Lop);
                lop.Ten_Lop = Ten_lop;
                lop.Ma_Nganh = Ma_Nganh;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa Lớp Học
        [HttpDelete]
        public bool XoaLopHoc(string Ma_Lop)
        {
            try
            {
                Lop lop = db.Lops.Single(d => d.Ma_Lop == Ma_Lop);
                db.Lops.DeleteOnSubmit(lop);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Danh sách thống kê số tiền nộp theo lớp đã nạp
        [HttpGet]
        public List<V_TongTienTheoLop> TongTienHocPhiDaNapTheoLop()
        {
            List<V_TongTienTheoLop> listDS = db.V_TongTienTheoLops.ToList();
            foreach (V_TongTienTheoLop p in listDS)
                p.ToString();
            return listDS;
        }
        // Danh sách thống kê số tiền nộp theo mã lớp tra cứu
        [HttpGet]
        public List<V_TongTienTheoLop> TongTienHocPhiDaNapTheoMaLop(string maLop)
        {
            List<V_TongTienTheoLop> listDS = db.V_TongTienTheoLops.Where(x => x.Ma_Lop == maLop).ToList();
            foreach (V_TongTienTheoLop p in listDS)
                p.ToString();
            return listDS;
        }
    }
}
