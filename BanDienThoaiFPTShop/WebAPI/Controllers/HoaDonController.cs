using BLL;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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

        //Tìm kiếm mã hóa đơn theo id
        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetHoaDonById(int id)
        {
            HoaDonModel hoadon = _hoaDonBL.GetHoadonByID(id);

            if (hoadon == null)
            {
                return NotFound();
            }

            return Ok(hoadon);
        }
    }
}
