using BLL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanDienThoai_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeBL _homeBL;

        public HomeController(IHomeBL homeBL)
        {
            _homeBL = homeBL;
        }

        [Route("GetAllChuyenMuc")]
        [HttpGet]
        public ActionResult<IEnumerable<ChuyenMuc>> GetAllChuyenMuc()
        {
            return _homeBL.GetAllChuyenMuc();
        }

        [Route("GetAllSlide")]
        [HttpGet]
        public ActionResult<IEnumerable<Slide>> GetAllSlide()
        {
            return _homeBL.GetAllSlide();
        }

    }
}
