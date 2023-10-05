using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class LoaiTaiKhoan
    {
        public LoaiTaiKhoan()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int MaLoai { get; set; }
        public string? TenLoai { get; set; }
        public string? MoTa { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
