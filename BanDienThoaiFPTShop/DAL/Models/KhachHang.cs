using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class KhachHang
    {
        public int Id { get; set; }
        public string? TenKh { get; set; }
        public bool GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
    }
}
