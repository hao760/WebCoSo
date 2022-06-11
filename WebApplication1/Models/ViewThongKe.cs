using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ViewThongKe
    {
        [Display(Name = "Tên tài khoản")]
        public string email { get; set; }

        [Display(Name = "Số lần mua")]
        public int soLanMua { get; set; }

        [Display(Name = "Tổng số tiền mua (VND)")]
        public long tongTien { get; set; }
    }
}