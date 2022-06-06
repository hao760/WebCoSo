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

    }
}