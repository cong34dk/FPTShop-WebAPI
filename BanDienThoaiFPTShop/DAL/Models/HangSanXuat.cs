using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HangSanXuat
    {
        public HangSanXuat()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        public int MaHang { get; set; }
        public string? TenHang { get; set; }
        public string? LinkWeb { get; set; }
        public string? AnhDaiDien { get; set; }

        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
