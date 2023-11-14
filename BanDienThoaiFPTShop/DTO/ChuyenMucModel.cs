using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuyenMucModel
    {
        public int MaChuyenMuc { get; set; }
        public int? MaChuyenMucCha { get; set; }
        public string? TenChuyenMuc { get; set; }
        public bool DacBiet { get; set; }
        public string? NoiDung { get; set; }
        public string? Link { get; set; }
    }
}
