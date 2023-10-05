using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ChiTietSanPham
    {
        public int MaChiTietSanPham { get; set; }
        public int? MaSanPham { get; set; }
        public int? MaNhaSanXuat { get; set; }
        public string MoTa { get; set; } = null!;
        public string? ChiTiet { get; set; }

        public virtual HangSanXuat? MaNhaSanXuatNavigation { get; set; }
        public virtual SanPham? MaSanPhamNavigation { get; set; }
    }
}
