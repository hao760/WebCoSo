using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ViewThongKe2
    {
        [Display(Name = "Tên Sản Phẩm")]
        public string tenHangHoa { get; set; }

        [Display(Name = "Số sản phẩm bán được")]
        public int soLuongBan { get; set; }

        [Display(Name = "Tổng tiền thu được")]
        public long tongTien { get; set; }
    }
}