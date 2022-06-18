using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachSanPham()
        {
           
            var Model = db.HangHoas;
            ViewBag.count = Model.Count();
            return View(Model.ToList());
        }
        //[HttpPost]
        //public JsonResult DanhSachSanPham(string tuKhoa)
        //{
        //    db = new Model1();
        //    HangHoa list = db.HangHoas.Where(s => s.TenHangHoa.StartsWith(tuKhoa)).FirstOrDefault();

        //    //list=db.HangHoas.Where(s=>s.TenHangHoa.StartsWith(tuKhoa)).FirstOrDefault();
        //    return Json(new { Message = list, JsonRequestBehavior.AllowGet });
        //}
        public ActionResult XoaSanPham(int id)
        {
            var temp1 = db.ChiTietHoaDons.Where(s => s.MaHangHoa == id).FirstOrDefault();
            if (temp1 == null)
            {
                HangHoa temp = db.HangHoas.Where(s => s.MaHangHoa == id).FirstOrDefault();
                db.HangHoas.Remove(temp);
                db.SaveChanges();
            }
            
            return RedirectToAction("DanhSachSanPham","Admin");
        }


        public ActionResult SuaSanPham(int id)
        {
            var temp = db.HangHoas.Where(s => s.MaHangHoa == id).FirstOrDefault();

            return View(temp);
        }
        [HttpPost]
        public ActionResult SuaSanPham(FormCollection f)
        {
            db = new Model1();
            int ma = Convert.ToInt32(f["MaHangHoa"]);
            String ten = f["TenHangHoa"];
            var soluong = f["SoLuongCon"];
            var thuongHieu = f["MaThuongHieu"];
            var loaiHang = f["MaLoaiHang"];
            var gia = Convert.ToDecimal(f["GiaBan"]);
            var temp = db.HangHoas.Where(s => s.MaHangHoa == ma).FirstOrDefault();
            if (temp != null)
            {
                temp.GiaBan = Convert.ToInt32(gia);
                temp.MaLoaiHang = Convert.ToInt32(loaiHang);
                temp.TenHangHoa = ten;
                temp.MaThuongHieu = Convert.ToInt32(thuongHieu);
                temp.SoLuongCon = Convert.ToInt32(soluong);
                db.SaveChanges();
            }

            return RedirectToAction("DanhSachSanPham", "Admin");
        }


        public ActionResult ThongKe()
        {
            List<ViewThongKe> listView = new List<ViewThongKe>();
            ViewThongKe view;
            List<int> maKH = db.KhachHangs.Select(s => s.MaKhachHang).ToList();
            foreach(var item in maKH)
            {
                view = new ViewThongKe();
                view.email = db.KhachHangs.Where(s => s.MaKhachHang == item).Select(s=>s.Email).FirstOrDefault();
                view.soLanMua = db.HoaDons.Where(s => s.MaKhachHang == item).Count();


                if(view.soLanMua!=0)
                    view.tongTien = (long)db.HoaDons.Where(s => s.MaKhachHang == item).Sum(s => s.TongTien);
                else
                    view.tongTien = 0;

               listView.Add(view);
            }
            return View(listView);
        }

        public ActionResult ThongKeTheoSanPham()
        {
            List<ViewThongKe2> listTemp = new List<ViewThongKe2>();
           
            db = new Model1();
            var listID = db.HangHoas.Select(s => s.MaHangHoa).ToList();
            foreach(var item in listID)
            {
                ViewThongKe2 temp = new ViewThongKe2();
                temp.tenHangHoa = db.HangHoas.Where(s => s.MaHangHoa == item).Select(s => s.TenHangHoa).FirstOrDefault();
                var giaban = db.HangHoas.Where(s => s.MaHangHoa == item).Select(s => s.GiaBan).FirstOrDefault();

                ChiTietHoaDon tonTai= db.ChiTietHoaDons.Where(s => s.MaHangHoa == item).FirstOrDefault();
                temp.soLuongBan = 0;
                if (tonTai!=null)
                    temp.soLuongBan = db.ChiTietHoaDons.Where(s => s.MaHangHoa == item).Sum(s => s.SoLuong);
                   
                temp.tongTien = Convert.ToInt32(giaban * temp.soLuongBan);
                listTemp.Add(temp);
            }
            return View(listTemp);
        }



        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        // Gần các giá trị người dùng nhập liệu cho các biến
        {


            var MaNhanVien = collection["MaNhanVien"];
            var matkhau = collection["Matkhau"];


            if (String.IsNullOrEmpty(MaNhanVien))
               ViewData["Loil"] = "Phải nhập Ma Nhan Vien";
            else if (String.IsNullOrEmpty(matkhau))
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            else
            {
                int ma = Convert.ToInt32(MaNhanVien);
                //Gần giá trị cho đổi tượng được tạo mới (kh)
                TaiKhoanNhanVien kh = db.TaiKhoanNhanViens.SingleOrDefault(n => n.MaTaiKhoan == ma && n.MatKhau == matkhau);
                if (kh != null)
                {
                   
                    return RedirectToAction("DanhSachSanPham", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";

            }
            return View();

        }

    }
}