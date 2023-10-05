using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ChiTietHoaDon
    {
        public int MaChiTietHoaDon { get; set; }
        public int? MaHoaDon { get; set; }
        public int? MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? TongGia { get; set; }

        public virtual HoaDon? MaHoaDonNavigation { get; set; }
        public virtual SanPham? MaSanPhamNavigation { get; set; }
    }
}
