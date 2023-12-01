using BLL;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanDienThoai_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBL _hoaDonBL;
        public HoaDonController(IHoaDonBL hoaDonBL)
        {
            _hoaDonBL = hoaDonBL;
        }
    }
}
