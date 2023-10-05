using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            ChiTietTaiKhoans = new HashSet<ChiTietTaiKhoan>();
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        public int MaTaiKhoan { get; set; }
        public int? LoaiTaiKhoan { get; set; }
        public string? TenTaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }

        public virtual LoaiTaiKhoan? LoaiTaiKhoanNavigation { get; set; }
        public virtual ICollection<ChiTietTaiKhoan> ChiTietTaiKhoans { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
