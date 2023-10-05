using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }

        public int MaHoaDon { get; set; }
        public int? MaNhaPhanPhoi { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? KieuThanhToan { get; set; }
        public int? MaTaiKhoan { get; set; }

        public virtual NhaPhanPhoi? MaNhaPhanPhoiNavigation { get; set; }
        public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    }
}
