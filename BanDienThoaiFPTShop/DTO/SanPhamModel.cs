using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamModel
    {
            // Identity không cần thiết trong DTO khi thêm mới vì nó được tạo tự động trong cơ sở dữ liệu.
            // Tuy nhiên, nó cần thiết khi cập nhật hoặc xóa, vì vậy nó được giữ ở đây.
            public int MaSanPham { get; set; }
            public int? MaChuyenMuc { get; set; }
            public string TenSanPham { get; set; }
            public string AnhDaiDien { get; set; }
            public decimal? Gia { get; set; }
            public decimal? GiaGiam { get; set; }
            public int? SoLuong { get; set; }
            public bool? TrangThai { get; set; }
            public int? LuotXem { get; set; }
            public bool DacBiet { get; set; }


    }
}
