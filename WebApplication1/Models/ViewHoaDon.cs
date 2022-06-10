using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class ViewHoaDon
    {
        public List<HoaDon> listHoaDon { get; set; }
        public List<ChiTietHoaDon> listChiTietHoaDon { get; set; }
        public List<HangHoa> listHangHoa { get; set; }
    }
}