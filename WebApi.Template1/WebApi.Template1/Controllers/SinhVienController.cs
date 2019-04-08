using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Template1.Controllers
{
    public class SinhVienController : ApiController
    {
        QLHPDataContext db = null;
        public SinhVienController()
        {
            db = new QLHPDataContext();
        }
        //Thêm sinh viên
        [HttpPost]
        public bool ThemSinhVien(string Ma_SV, string Ma_Lop, string Ho_Ten, DateTime Ngay_Sinh, string Gioi_Tinh, string Khoa_Hoc)
        {
            try
            {
                Sinh_vien sv = new Sinh_vien();
                sv.Ma_SV = Ma_SV;
                sv.Ma_Lop = Ma_Lop;
                sv.Ho_Ten = Ho_Ten;
                sv.Ngay_Sinh = Ngay_Sinh;
                sv.Gioi_Tinh = Gioi_Tinh;
                sv.Khoa_Hoc = Khoa_Hoc;
                db.Sinh_viens.InsertOnSubmit(sv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Sửa sinh viên
        [HttpPut]
        public bool SuaThongTinSinhVien(string Ma_SV, string Ma_Lop, string Ho_Ten, DateTime Ngay_Sinh, string Gioi_Tinh, string Khoa_Hoc)
        {
            try
            {
                Sinh_vien sv = db.Sinh_viens.Single(d => d.Ma_SV == Ma_SV);
                sv.Ma_Lop = Ma_Lop;
                sv.Ho_Ten = Ho_Ten;
                sv.Ngay_Sinh = Ngay_Sinh;
                sv.Gioi_Tinh = Gioi_Tinh;
                sv.Khoa_Hoc = Khoa_Hoc;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa sinh viên
        [HttpDelete]
        public bool XoaSinhVien(string Ma_SV)
        {
            try
            {
                Sinh_vien sv = db.Sinh_viens.Single(d => d.Ma_SV == Ma_SV);
                db.Sinh_viens.DeleteOnSubmit(sv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Danh sách thống kê số tiền nộp của tất cả sinh viên
        [HttpGet]
        public List<V_TongTienTheoSinhVien> TongTienHocPhiDaNapTheoSinhVien()
        {
            List<V_TongTienTheoSinhVien> listDS = db.V_TongTienTheoSinhViens.ToList();
            foreach (V_TongTienTheoSinhVien p in listDS)
                p.ToString();
            return listDS;
        }
        // Danh sách thống kê số tiền nộp theo mã sinh viên
        [HttpGet]
        public List<V_TongTienTheoSinhVien> TongTienHocPhiDaNapTheoMaSV(string maSV)
        {
            List<V_TongTienTheoSinhVien> listDS = db.V_TongTienTheoSinhViens.Where(x => x.Ma_SV == maSV).ToList();
            foreach (V_TongTienTheoSinhVien p in listDS)
                p.ToString();
            return listDS;
        }
    }
}
