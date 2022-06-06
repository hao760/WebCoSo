namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        public int MaHangHoa { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]
        public string TenHangHoa { get; set; }

        public int? MaThuongHieu { get; set; }

        public int? MaLoaiHang { get; set; }
        [Display(Name = "Số lượng còn")]
        public int? SoLuongCon { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá bán")]
        public decimal? GiaBan { get; set; }

        public int? MaKhuyenMai { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string AnhSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual LoaiHangHoa LoaiHangHoa { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
