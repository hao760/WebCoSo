using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace WebApplication1.Controllers
{
    public class NguoiDungController : Controller
    {
        Model1 db = new Model1();
        // GET: NguoiDung
        

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection)
        {
            TaiKhoanKhachHang kh = new TaiKhoanKhachHang();
            var email = collection["Email"];
            var matkhau=collection["Matkhau"];
            var tenhienthi = collection["TenHienThi"];
            kh.Email = email;
            kh.MatKhau = matkhau;
            kh.TenHienThi = tenhienthi;
            db.TaiKhoanKhachHangs.Add(kh);
            db.SaveChanges();
            ViewBag.Thongbao = "Chúc mừng đăng ký thành công";
           
            return RedirectToAction("Dangnhap");
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        // Gần các giá trị người dùng nhập liệu cho các biến
        {


            var Email = collection["Email"];
            var matkhau = collection["Matkhau"];


            emailKhachHang = Email;

            if (String.IsNullOrEmpty(Email))
            
                ViewData["Loil"] = "Phải nhập Email";
                else if (String.IsNullOrEmpty(matkhau))
                    ViewData["Loi2"] = "Phải nhập mật khẩu";
                else
                {
                    //Gần giá trị cho đổi tượng được tạo mới (kh)
                    TaiKhoanKhachHang kh = db.TaiKhoanKhachHangs.SingleOrDefault(n => n.Email == Email && n.MatKhau == matkhau);
                    if (kh != null)
                    {
                        //ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                        Session["Taikhoan"] = kh;
                    TempData["mydata"] = Email;


                    return RedirectToAction("GioHang", "GioHang");
                }
                    else
                        ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        
            }
            return View();

        }

        public ActionResult QuenMatKhau()
        {
            ViewBag.Message = "";
            return View();
            
        }

        static string codeMail = "9";
        static string emailKhachHang ;

        [HttpPost]
        public ActionResult QuenMatKhau(WebApplication1.Models.EMail mail)
        {

            try
            {
                MailMessage mm = new MailMessage("qhao74155@gmail.com", mail.To);
                Random rd = new Random();
                codeMail = rd.Next(1000, 9999).ToString();
                mm.Subject = "Email xác nhận";//mail.Subject;
                mm.Body = "Chào bạn. Mã xác thực tài khoản của bạn là  :"+ codeMail;//mail.Body;
                mm.IsBodyHtml = false;
                emailKhachHang = mail.To;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential("qhao74155@gmail.com", "1luongquochao");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
                ViewBag.Message = "Successfully!";
            }
            catch
            {
                ViewBag.Message = "Mail That Bai!";
                return View();
            }
            return RedirectToAction("NhanMail", "Nguoidung");
        }
        public ActionResult NhanMail()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult NhanMail(FormCollection collection)
        {
            //if(collection["pass"])
            if (collection["codeMail"].Equals(codeMail)==true)
            {
                ViewBag.Message = "Nhap mã đúng";
                var user = emailKhachHang;
                var temp= db.TaiKhoanKhachHangs.Where(s => s.Email == user).FirstOrDefault();
                temp.MatKhau = collection["pass"];
                db.SaveChanges();
                Thread.Sleep(2000);
                return RedirectToAction("Dangnhap");
            }
            else
            {
                ViewBag.Message = "Nhập mã sai!";
                return View();
            }
        }






        public ActionResult HoSo()
        {
            KhachHang temp = new KhachHang();
            temp = db.KhachHangs.Where(s => s.Email == emailKhachHang).SingleOrDefault();
            if (temp == null)
            {
                temp = new KhachHang();
                temp.TenKhachHang = "";
                temp.GioiTinh = "";
                temp.Email = emailKhachHang;
            }
            
            return View(temp);

        }
        [HttpPost]
        public ActionResult HoSo(FormCollection collection)
        // Gần các giá trị người dùng nhập liệu cho các biến
        {
            var gioiTinh = collection["GioiTinh"];
            var email = collection["Email"];
            var tenKhachHang = collection["TenKhachHang"];

            
                //Gần giá trị cho đổi tượng được tạo mới (kh)
                KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.Email == email );
                if (kh != null)
                {
                    kh.TenKhachHang = tenKhachHang;
                    kh.GioiTinh = gioiTinh;
                    db.SaveChanges();
            }
            else
            {
                kh = new KhachHang();
                kh.TenKhachHang = tenKhachHang;
                kh.GioiTinh = gioiTinh;
                kh.Email = email;
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }
            return View();

        }

    }
}