using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class NhaPhanPhoi
    {
        public NhaPhanPhoi()
        {
            HoaDonNhaps = new HashSet<HoaDonNhap>();
            MaSanPhams = new HashSet<SanPham>();
        }

        public int MaNhaPhanPhoi { get; set; }
        public string? TenNhaPhanPhoi { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Fax { get; set; }
        public string? MoTa { get; set; }

        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }

        public virtual ICollection<SanPham> MaSanPhams { get; set; }
    }
}
