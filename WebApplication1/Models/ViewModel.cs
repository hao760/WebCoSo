using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class ViewModel
    {
        public List<HangHoa> hangHoa { get; set; }
        public List<ThuongHieu> thuongHieu { get; set; }
        public List<LoaiHangHoa> loaiHangHoa { get; set; }
    }
}