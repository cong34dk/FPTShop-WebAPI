using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class QuanTri
    {
        public int Id { get; set; }
        public string? Hoten { get; set; }
        public string? Diachi { get; set; }
        public string? Gioitinh { get; set; }
        public string? Email { get; set; }
        public string? Taikhoan { get; set; }
        public string? Matkhau { get; set; }
    }
}
