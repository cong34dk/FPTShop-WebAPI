using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISanPhamDA
    {
        void InsertSanPham(SanPhamModel sanPham);
        SanPhamModel GetSanPhamByID(int maSanPham);
        void UpdateSanPham(int maSanPham, SanPhamModel sanPham);
        void DeleteSanPham(int maSanPham);
        List<SanPhamModel> GetAllSanPhams();

        // Phương thức tìm kiếm sản phẩm với phân trang và trả về tổng số lượng sản phẩm
        List<SanPhamModel> SearchSanPhams(string keyword, int pageIndex, int pageSize, out long total);
    }
}
