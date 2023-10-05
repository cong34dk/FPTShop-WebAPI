using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaHoaDon { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public decimal? TongGia { get; set; }
        public string? TenKh { get; set; }
        public bool GioiTinh { get; set; }
        public string? Diachi { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChiGiaoHang { get; set; }
        public DateTime? ThoiGianGiaoHang { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
