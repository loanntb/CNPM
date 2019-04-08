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

        [WebMethod(Description = "Thông tin danh sách chi tiết sinh viên đã nạp học phí theo mã sinh viên tra cứu")]
        //Tra cứu thông tin danh sách học đã nạp học phí theo sinh vien
        public V_DSNop TraCuuDanhSachNapHocPhiTheoMSV(String nhapMSV)
        {
            V_DSNop p = db.V_DSNops.FirstOrDefault(x => x.Ma_SV == nhapMSV);
            return p;
        }
        //Tra cứu thông tin danh sách học đã nạp học phí theo ten sinh viên
        [WebMethod(Description = "Thông tin danh sách chi tiết sinh viên đã nạp học phí theo tên sinh viên tra cứu")]
        public List<V_DSNop> TracuuDanhSachNapHocPhiTheoTen(String nhapTenSV)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ho_Ten == nhapTenSV).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }

        //Tra cứu thông tin danh sách học đã nạp học phí theo ma lop
        [WebMethod(Description = "Thông tin danh sách chi tiết sinh viên đã nạp học phí theo lớp tra cứu")]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoMaLop(String nhapMaLop)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ma_Lop == nhapMaLop).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }

        //Tra cứu thông tin danh sách học đã nạp học phí theo nganh
        [WebMethod(Description = "Thông tin danh sách chi tiết sinh viên đã nạp học phí theo ngành tra cứu")]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoNganh(String nhapTenNganh)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ten_Nganh == nhapTenNganh).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Tra cứu thông tin danh sách học đã nạp học phí theo ngày  nạp ???
        [WebMethod(Description = "Thông tin danh sách chi tiết sinh viên đã nạp học phí theo ngày tra cứu")]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoNgayNap(DateTime nhapNgayNap)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ngay_Nap == nhapNgayNap).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Tra cứu thông tin danh sách học đã nạp học phí theo khoảng tiền nạp
        [WebMethod(Description = "Thông tin danh sách chi tiết sinh viên đã nạp học phí theo khoảng tiền")]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoKhoangTienNap(float soTienThapNhat, float soTienCaoNhat)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.So_Tien > soTienThapNhat && x.So_Tien < soTienCaoNhat).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Hiển thị thông tin danh sách học đã nạp học phí 
        [WebMethod(Description = "Thông tin danh sách học đã nạp học phí")]
        public List<V_DSNop> danhSachDaNapHocPhi()
        {
            List<V_DSNop> listDS = db.V_DSNops.ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Thống kê số tiền nộp theo ngày ???
        [WebMethod(Description = "Danh sách thống kê số tiền nộp  theo ngày")]
        public List<V_TongTienTheoNgay> TongTienHocPhiDaNapTheoNgay()
        {
            List<V_TongTienTheoNgay> listDS = db.V_TongTienTheoNgays.ToList();
            foreach (V_TongTienTheoNgay p in listDS)
                p.ToString();
            return listDS;
        }
        //Danh sách thống kê số tiền nộp theo lớp đã nạp
        [WebMethod(Description = "Danh sách thống kê số tiền nộp của tất cả lớp đã nạp")]
        public List<V_TongTienTheoLop> TongTienHocPhiDaNapTheoLop()
        {
            List<V_TongTienTheoLop> listDS = db.V_TongTienTheoLops.ToList();
            foreach (V_TongTienTheoLop p in listDS)
                p.ToString();
            return listDS;
        }
        //Danh sách thống kê số tiền nộp theo ngành đã nạp
        [WebMethod(Description = "Danh sách thống kê số tiền nộp  của tất cả ngành đã nạp")]
        public List<V_TongTienTheoNganh> TongTienHocPhiDaNapTheoNganh()
        {
            List<V_TongTienTheoNganh> listDS = db.V_TongTienTheoNganhs.ToList();
            foreach (V_TongTienTheoNganh p in listDS)
                p.ToString();
            return listDS;
        }
        //Danh sách thống kê số tiền nộp của tất cả sinh viên
        [WebMethod(Description = "Danh sách thống kê số tiền nộp  của tất cả sinh viên")]
        public List<V_TongTienTheoSinhVien> TongTienHocPhiDaNapTheoSinhVien()
        {
            List<V_TongTienTheoSinhVien> listDS = db.V_TongTienTheoSinhViens.ToList();
            foreach (V_TongTienTheoSinhVien p in listDS)
                p.ToString();
            return listDS;
        }
        //Danh sách thống kê số tiền nộp theo ngày tra cứu
        [WebMethod(Description = "Danh sách thống kê số tiền nộp  theo ngày nạp tra cứu")]
        public List<V_TongTienTheoNgay> TongTienHocPhiDaNapTheoNgayNhap(DateTime nhapNgay)
         {
             List<V_TongTienTheoNgay> listDS = db.V_TongTienTheoNgays.Where(x => x.Ngay_Nap == nhapNgay).ToList();
             foreach (V_TongTienTheoNgay p in listDS)
                 p.ToString();
             return listDS;
         }
        // Danh sách thống kê số tiền nộp theo mã lớp tra cứu
        [WebMethod(Description = "Danh sách thống kê số tiền nộp  theo mã lớp tra cứu")]
        public List<V_TongTienTheoLop> TongTienHocPhiDaNapTheoMaLop(string maLop)
        {
            List<V_TongTienTheoLop> listDS = db.V_TongTienTheoLops.Where(x => x.Ma_Lop == maLop).ToList();
            foreach (V_TongTienTheoLop p in listDS)
                p.ToString();
            return listDS;
        }
        // Danh sách thống kê số tiền nộp theo ngành tra cứu
        [WebMethod(Description = "Danh sách thống kê số tiền nộp  theo ngành tra cứu")]
        public List<V_TongTienTheoNganh> TongTienHocPhiDaNapTheoTenNganh(string tenNganh)
        {
            List<V_TongTienTheoNganh> listDS = db.V_TongTienTheoNganhs.Where(x => x.Ten_Nganh == tenNganh).ToList();
            foreach (V_TongTienTheoNganh p in listDS)
                p.ToString();
            return listDS;
        }
        // Danh sách thống kê số tiền nộp theo mã sinh viên
        [WebMethod(Description = "Danh sách thống kê số tiền nộp theo mã sinh viên")]
        public List<V_TongTienTheoSinhVien> TongTienHocPhiDaNapTheoMaSV(string maSV)
        {
            List<V_TongTienTheoSinhVien> listDS = db.V_TongTienTheoSinhViens.Where(x => x.Ma_SV == maSV).ToList();
            foreach (V_TongTienTheoSinhVien p in listDS)
                p.ToString();
            return listDS;
        }
        //Thêm ngành học
        [WebMethod(Description = "Thêm ngành học")]
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
        //Thêm lớp học
        [WebMethod(Description = "Thêm Lớp")]
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
        //Thêm sinh viên
        [WebMethod(Description = "Thêm sinh viên")]
        public bool ThemSinhVien( string Ma_SV, string Ma_Lop, string Ho_Ten,  DateTime Ngay_Sinh, string Gioi_Tinh, string Khoa_Hoc)
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
        //Thêm số phiếu đã nạp
        [WebMethod(Description = "Thêm số phiếu đã nạp")]
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
      //  sửa ngành học
        [WebMethod(Description = "Sửa ngành học")]
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
        //Sửa lớp học
        [WebMethod(Description = "Sửa thông tin lớp")]
        public bool SuaThongTinLop(string Ma_Lop, string Ten_lop, string Ma_Nganh)
        {
            try
            {
                Lop lop = db.Lops.Single(d => d.Ma_Lop == Ma_Lop);
                lop.Ten_Lop = Ten_lop;
                lop.Ma_Nganh= Ma_Nganh;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Sửa sinh viên
        [WebMethod(Description = "  Sửa thông tin sinh viên")]
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
        //Sửa số phiếu đã nạp
        [WebMethod(Description = "Sửa thông tin số phiếu đã nạp")]
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
        //Xóa sinh viên
        [WebMethod(Description = "  Xóa sinh viên")]
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
        //Xóa Ngành Học
        [WebMethod(Description = "  Xóa ngành học")]
        public bool XoaNganhHoc(string Ma_Nganh)
        {
            try
            {
                Nganh nganh = db.Nganhs.Single(d => d.Ma_Nganh== Ma_Nganh);
                db.Nganhs.DeleteOnSubmit(nganh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa Lớp Học
        [WebMethod(Description = "  Xóa Lớp học")]
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
        //Xóa Phiếu Nạp Học Phí
        [WebMethod(Description = "Xóa Phiếu Nạp Học Phí")]
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
    }
}
