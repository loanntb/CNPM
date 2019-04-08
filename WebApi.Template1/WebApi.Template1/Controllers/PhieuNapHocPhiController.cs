using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Template1.Controllers
{
    public class PhieuNapHocPhiController : ApiController
    {
        QLHPDataContext db = null;
        public PhieuNapHocPhiController()
        {
            db = new QLHPDataContext();
        }
        //Sửa số phiếu đã nạp
        [HttpPut]
        public bool SuaThongTinSoPhieuDaNap(string Ma_So_Phieu, string Ma_SV, DateTime Ngay_Nap, float So_Tien)
        {
            try
            {
                Phieu_Nop pn = db.Phieu_Nops.Single(d => d.Ma_So_Phieu == Ma_So_Phieu);
                pn.Ma_SV = Ma_SV;
                pn.Ngay_Nap = Ngay_Nap;
                pn.So_Tien = So_Tien;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Thêm số phiếu đã nạp
        [HttpPost]
        public bool ThemSoPhieu(string Ma_So_Phieu, string Ma_SV, DateTime Ngay_Nap, float So_Tien)
        {
            try
            {
                Phieu_Nop pn = new Phieu_Nop();
                pn.Ma_So_Phieu = Ma_So_Phieu;
                pn.Ma_SV = Ma_SV;
                pn.Ngay_Nap = Ngay_Nap;
                pn.So_Tien = So_Tien;
                db.Phieu_Nops.InsertOnSubmit(pn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        //Xóa Phiếu Nạp Học Phí
        public bool XoaPhieuNapHocPhi(string MaSoPhieu)
        {
            try
            {
                Phieu_Nop pn = db.Phieu_Nops.Single(d => d.Ma_So_Phieu == MaSoPhieu);
                db.Phieu_Nops.DeleteOnSubmit(pn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        //Thống kê số tiền nộp theo ngày
        [HttpGet]
        public List<V_TongTienTheoNgay> TongTienHocPhiDaNapTheoNgay()
        {
            List<V_TongTienTheoNgay> listDS = db.V_TongTienTheoNgays.ToList();
            foreach (V_TongTienTheoNgay p in listDS)
                p.ToString();
            return listDS;
        }
        //Danh sách thống kê số tiền nộp theo ngày tra cứu ???
        [HttpGet]
        public List<V_TongTienTheoNgay> TongTienHocPhiDaNapTheoNgayNhap(DateTime nhapNgay)
        {
            List<V_TongTienTheoNgay> listDS = db.V_TongTienTheoNgays.Where(x => x.Ngay_Nap == nhapNgay).ToList();
            foreach (V_TongTienTheoNgay p in listDS)
                p.ToString();
            return listDS;
        }
    }
}
