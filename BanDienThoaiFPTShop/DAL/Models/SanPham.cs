using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            MaNhaPhanPhois = new HashSet<NhaPhanPhoi>();
        }

        public int MaSanPham { get; set; }
        public int? MaChuyenMuc { get; set; }
        public string? TenSanPham { get; set; }
        public string? AnhDaiDien { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiaGiam { get; set; }
        public int? SoLuong { get; set; }
        public bool? TrangThai { get; set; }
        public int? LuotXem { get; set; }
        public bool DacBiet { get; set; }

        public virtual ChuyenMuc? MaChuyenMucNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

        public virtual ICollection<NhaPhanPhoi> MaNhaPhanPhois { get; set; }
    }
}
