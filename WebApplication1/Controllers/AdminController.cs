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

    }
}