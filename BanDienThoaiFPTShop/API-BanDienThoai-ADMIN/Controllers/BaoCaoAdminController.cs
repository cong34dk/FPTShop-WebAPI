using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_BanDienThoai_ADMIN.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class BaoCaoAdminController : ControllerBase
    {
        private readonly IBaoCaoAdminBL _baoCaoAdminBL;

        public BaoCaoAdminController(IBaoCaoAdminBL baoCaoAdminBL)
        {
            _baoCaoAdminBL = baoCaoAdminBL;
        }

        // Lấy tổng doanh thu
        [HttpGet("get-tong-doanh-thu")]
        public IActionResult GetTotalRevenue()
        {
            try
            {
                var totalRevenue = _baoCaoAdminBL.GetTotalRevenue();
                return Ok(new { totalRevenue });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Lấy tổng doanh thu theo khoảng thời gian
        [HttpGet("get-tong-doanh-thu-theo-thoi-gian")]
        public IActionResult GetTotalRevenueByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var totalRevenue = _baoCaoAdminBL.GetTotalRevenueByDateRange(startDate, endDate);
                return Ok(new { startDate, endDate, totalRevenue });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Thêm các phương thức báo cáo khác theo yêu cầu
    }
}
