using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class ViewModel2
    {
        public List<KhachHang> khachHang { get; set; }
        public List<GioHang> gioHang { get; set; }
    }
}