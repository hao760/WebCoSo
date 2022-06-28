using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using OfficeOpenXml;


namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }

        public static string eMailkhachhang="";
        public List<GioHang> LayGioHang()
        {
            List < GioHang > list= Session["GioHang"] as List<GioHang>;
            if (list == null)
            {
                list = new List<GioHang>();
                Session["GioHang"] = list;
            }
            

            return list;
        }

        public void ExportToExcel()
        {
            List<GioHang> emplist = Session["GioHang"] as List<GioHang>;


            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            

            ws.Cells["A2"].Value = "Hóa đơn:";
            ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A5"].Value = "Mã sản phẩm";
            ws.Cells["B5"].Value = "Tên sản phẩm";
            ws.Cells["C5"].Value = "Soluong";
            ws.Cells["D5"].Value = "Giá bán VND";
            ws.Cells["E5"].Value = "Thành tiền";

            int rowStart = 6;
            foreach (var item in emplist)
            {

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.MaSP;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.TenSP;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Soluong;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.GiaBan;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.ThanhTien;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }



        public double TinhTongTien()
        {
            List<GioHang> list = Session["GioHang"] as List<GioHang>;
            double tong = 0;
            if (list != null)
            {
                tong = list.Sum(s => @Convert.ToInt32(s.ThanhTien));
            }
            return tong;
        }
        public double TinhSoLuong()
        {
            List<GioHang> list = Session["GioHang"] as List<GioHang>;
            double sl = 0;
            if (list != null)
            {
                sl = list.Sum(s => s.Soluong);
            }
            return sl;
        }



        [HttpPost]
        public JsonResult Themvaogio(int masp)
        {
            if(Session["Taikhoan"] == null)
                    return Json(new { Message = "1", JsonRequestBehavior.AllowGet });
            string mess ;
            
            List<GioHang> list = LayGioHang();
            GioHang sanpham = list.Find(s => s.MaSP == masp);
            
            if (sanpham == null)
            {
                sanpham = new GioHang(masp);
                list.Add(sanpham);
                mess = "Thêm mới thành công";
            }
            else
            {
                sanpham.Soluong++;
                mess = "Đã cộng 1 vào giỏ";
            }
            int soLuong1 = (int)TinhSoLuong();
            //return Json("Response from Create");
            return Json(new { Message = mess, JsonRequestBehavior.AllowGet ,soLuong= soLuong1});
        }

        public ActionResult UpdateSoLuong(int masp, FormCollection f)
        {
            List<GioHang> list = LayGioHang();
            GioHang sanPham = list.SingleOrDefault(n => n.MaSP == masp);
            if (sanPham != null)
                sanPham.Soluong = int.Parse(f["SoLuong"].ToString());
            return RedirectToAction("GioHang");
        }


        public ActionResult XoaGioHang(int masp, string url)
        {
            List<GioHang> list = LayGioHang();
            list.RemoveAll(s => s.MaSP == masp);
            return Redirect(url);
        }

        public ActionResult GioHang()
        {
            if (eMailkhachhang == "")
            {
                eMailkhachhang = TempData["mydata"] as string;
                Session["user"] = eMailkhachhang;
            }
           
            List<GioHang> list = LayGioHang();
           
            ViewBag.TongTien = TinhTongTien();
            return View(list);
        }
        
        // Cap nhat Giỏ hàng



        public ActionResult CapnhatGiohang(FormCollection f)//có begin form nó mới tới đây
        {
            List<GioHang> lstGiohang = LayGioHang();
            //GioHang sanpham;
            //// Kiem tra sach da co trong Session["Giohang"]
            //foreach (var item in f)
            //    sanpham = lstGiohang.SingleOrDefault(n => n.iMasach iMaSP);
            return View();
            
            
        }
        
        public ActionResult DatHang()
        {
            if (Session["GioHang"] == null)
                RedirectToAction("Index", "Home");
            List <GioHang> lstGiohang = LayGioHang();
            ViewBag.TongTien = TinhTongTien();
            eMailkhachhang = Session["user"] as string;
            return View(lstGiohang);
        }
        
        public ActionResult Mua()
        {
            if (Session["GioHang"] == null)
                RedirectToAction("Index", "Home");

            HoaDon hd =new HoaDon();
            string aa = Session["user"] as string;
            KhachHang kh = db.KhachHangs.Where(s => s.Email == aa).FirstOrDefault();
            List<GioHang> lstGiohang = LayGioHang();
            hd.MaKhachHang= kh.MaKhachHang;
            hd.NgayBan= DateTime.Now;
            hd.TongTien =Convert.ToDecimal(TinhTongTien());
            //var ngaygiao = String.Format("{0:MM/dd/yyyy)", collection["Ngaygiao"]);
            //ddh.Ngaygiao = DateTime.Parse(ngaygiao);
            db.HoaDons.Add(hd);
            db.SaveChanges();
            // Them chi tiet don hang
            foreach (var item in lstGiohang)
            {
                HangHoa sanPhamMua = db.HangHoas.Where(s => s.MaHangHoa == item.MaSP).FirstOrDefault();

                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHoaDon = hd.MaHoaDon;
                cthd.MaHangHoa= item.MaSP;
                cthd.SoLuong = item.Soluong;
                sanPhamMua.SoLuongCon -= item.Soluong;
                //cthd. = (decimal)item.dDongia;
                db.ChiTietHoaDons.Add(cthd);

            }
            db.SaveChanges();
            Session["Giohang"] = null;
            ViewData["DaMua"] = "Đã Mua thành công";
            return RedirectToAction("GioHang", "Giohang");

        }




    }
}