using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ChiTietHoaDonNhap
    {
        public int Id { get; set; }
        public int? MaHoaDon { get; set; }
        public int? MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public string? DonViTinh { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? TongTien { get; set; }

        public virtual HoaDonNhap? MaHoaDonNavigation { get; set; }
        public virtual SanPham? MaSanPhamNavigation { get; set; }
    }
}
