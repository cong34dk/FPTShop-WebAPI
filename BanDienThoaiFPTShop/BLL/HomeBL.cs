using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
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
        public List<ChuyenMuc> GetAllChuyenMuc()
        {
            return _homeDA.GetAllChuyenMuc();
        }
        public List<Slide> GetAllSlide()
        {
            return _homeDA.GetAllSlide();
        }
    }
}
