using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Template1.Controllers
{
    public class DSNopController : ApiController
    {
        QLHPDataContext db = null;
        public DSNopController()
        {
            db = new QLHPDataContext();
        }
  
        [HttpGet]
        //Tra cứu thông tin danh sách học đã nạp học phí theo sinh vien
        public V_DSNop TraCuuDanhSachNapHocPhiTheoMSV(String nhapMSV)
        {
            V_DSNop p = db.V_DSNops.FirstOrDefault(x => x.Ma_SV == nhapMSV);
            return p;
        }
     
        [HttpGet]
        //Tra cứu thông tin danh sách học đã nạp học phí theo ten sinh viên
        public List<V_DSNop> TracuuDanhSachNapHocPhiTheoTen(String nhapTenSV)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ho_Ten == nhapTenSV).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Tra cứu thông tin danh sách học đã nạp học phí theo ma lop
        [HttpGet]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoMaLop(String nhapMaLop)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ma_Lop == nhapMaLop).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }

        //Tra cứu thông tin danh sách học đã nạp học phí theo nganh
        [HttpGet]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoNganh(String nhapTenNganh)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ten_Nganh == nhapTenNganh).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Tra cứu thông tin danh sách học đã nạp học phí theo ngày nạp???
        [HttpGet]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoNgayNap(DateTime nhapNgayNap)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.Ngay_Nap == nhapNgayNap).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Tra cứu thông tin danh sách học đã nạp học phí theo khoảng tiền nạp
        [HttpGet]
        public List<V_DSNop> TraCuuDanhSachNapHocPhiTheoKhoangTienNap(float soTienThapNhat, float soTienCaoNhat)
        {
            List<V_DSNop> listDS = db.V_DSNops.Where(x => x.So_Tien > soTienThapNhat && x.So_Tien < soTienCaoNhat).ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        //Hiển thị thông tin danh sách học đã nạp học phí 
        [HttpGet]
        public List<V_DSNop> danhSachDaNapHocPhi()
        {
            List<V_DSNop> listDS = db.V_DSNops.ToList();
            foreach (V_DSNop p in listDS)
                p.ToString();
            return listDS;
        }
        
    }

}
