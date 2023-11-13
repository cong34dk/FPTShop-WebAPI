using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ChuyenMuc
    {
        public ChuyenMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaChuyenMuc { get; set; }
        public int? MaChuyenMucCha { get; set; }
        public string? TenChuyenMuc { get; set; }
        public bool DacBiet { get; set; }
        public string? NoiDung { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
