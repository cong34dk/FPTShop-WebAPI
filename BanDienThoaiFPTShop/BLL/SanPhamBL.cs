using DTO;
using DAL.Interfaces;
using BLL.Interfaces;

namespace BLL
{
    public class SanPhamBL : ISanPhamBL
    {
        private ISanPhamDA _sanPhamDA;

        public SanPhamBL(ISanPhamDA sanPhamDA)
        {
            _sanPhamDA = sanPhamDA;
        }

        public void InsertSanPham(SanPhamModel sanPham)
        {
            _sanPhamDA.InsertSanPham(sanPham);
        }

        public SanPhamModel GetSanPhamByID(int maSanPham)
        {
            return _sanPhamDA.GetSanPhamByID(maSanPham);
        }

        public void UpdateSanPham(int maSanPham, SanPhamModel sanPham)
        {
            _sanPhamDA.UpdateSanPham(maSanPham, sanPham);
        }

        public void DeleteSanPham(int maSanPham)
        {
            _sanPhamDA.DeleteSanPham(maSanPham);
        }

        public List<SanPhamModel> GetAllSanPhams()
        {
            return _sanPhamDA.GetAllSanPhams();
        }

        public List<SanPhamModel> SearchSanPhams(string keyword, int pageIndex, int pageSize, out long total)
        {
            return _sanPhamDA.SearchSanPhams(keyword, pageIndex, pageSize, out total);
        }

        //Phân trang
        public List<SanPhamModel> GetPagedProducts(int pageNumber, int pageSize, out int totalPages)
        {
            return _sanPhamDA.GetPagedProducts(pageNumber, pageSize, out totalPages);
        }
    }
}
