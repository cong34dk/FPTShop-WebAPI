using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHomeBL
    {
        List<ChuyenMuc> GetAllChuyenMuc();
        ChuyenMucModel GetChuyenMucByID(int maChuyenMuc);
        List<Slide> GetAllSlide();
        SlideModel GetSlideByID(int maAnh);
        SanPhamModel GetSanPhamByID(int maSanPham);
        List<SanPhamModel> GetAllSanPhams();
        List<QuangCaoDTO> GetAllQuangCaos();

        //Phân trang
        List<SanPhamModel> GetPagedProducts(int pageNumber, int pageSize, out int totalPages);

    }
}
