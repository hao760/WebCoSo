using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class GioHang
    {
        Model1 db = new Model1();
        public int MaSP { get; set; }

        public string TenSP { get; set; }

        public int GiaBan { get; set; }

        public string Anh { get; set; }

        public int Soluong { get; set; }

        public string ThanhTien
        {
            get { return (Soluong * GiaBan).ToString(); }
        }

        public GioHang(int masp)
        {
            MaSP = masp;
            var sanpham = db.HangHoas.Single(s => s.MaHangHoa == masp);
            TenSP = sanpham.TenHangHoa;
            GiaBan = Convert.ToInt32(sanpham.GiaBan);
            Anh = sanpham.AnhSanPham;
            Soluong = 1;
        }
    }
}