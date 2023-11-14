using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HomeBL : IHomeBL
    {

        private IHomeDA _homeDA;

        public HomeBL(IHomeDA homeDA)
        {
            this._homeDA = homeDA;
        }
        public ChuyenMucModel GetChuyenMucByID(int maChuyenMuc)
        {
            return _homeDA.GetChuyenMucByID(maChuyenMuc);
        }
        public List<ChuyenMuc> GetAllChuyenMuc()
        {
            return _homeDA.GetAllChuyenMuc();
        }

        public SlideModel GetSlideByID(int maAnh)
        {
            return _homeDA.GetSlideByID(maAnh);
        }
        public List<Slide> GetAllSlide()
        {
            return _homeDA.GetAllSlide();
        }
        public SanPhamModel GetSanPhamByID(int maSanPham)
        {
            return _homeDA.GetSanPhamByID(maSanPham);
        }
        public List<SanPhamModel> GetAllSanPhams()
        {
            return _homeDA.GetAllSanPhams();
        }
    }
}
