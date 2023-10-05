using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TinTuc
    {
        public int MaTinTuc { get; set; }
        public string? TieuDe { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? MoTa { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? ChiTiet { get; set; }
        public int? LuotXem { get; set; }
    }
}
