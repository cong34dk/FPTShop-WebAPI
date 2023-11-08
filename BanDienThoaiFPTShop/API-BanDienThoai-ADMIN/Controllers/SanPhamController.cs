using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanDienThoai_ADMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamBL _sanPhamBL;

        public SanPhamController(ISanPhamBL sanPhamBL)
        {
            _sanPhamBL = sanPhamBL;
        }

        // Thêm mới sản phẩm
        [HttpPost("create-SanPham")]
        public IActionResult CreateSanPham([FromBody] SanPhamModel model)
        {
            try
            {
                _sanPhamBL.InsertSanPham(model);
                return Ok(new { message = "Sản phẩm đã được thêm thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Lấy thông tin sản phẩm theo ID
        [HttpGet("get-by-id/{id}")]
        public ActionResult<SanPhamModel> GetSanPhamById(int id)
        {
            try
            {
                var sanPham = _sanPhamBL.GetSanPhamByID(id);
                if (sanPham != null)
                {
                    return Ok(sanPham);
                }
                return NotFound(new { message = "Sản phẩm không tìm thấy." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Cập nhật thông tin sản phẩm
        [HttpPut("update-SanPham")]
        public IActionResult UpdateSanPham([FromBody] SanPhamModel model)
        {
            try
            {
                _sanPhamBL.UpdateSanPham(model.MaSanPham, model);
                return Ok(new { message = "Cập nhật sản phẩm thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Xóa sản phẩm theo ID
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSanPham(int id)
        {
            try
            {
                _sanPhamBL.DeleteSanPham(id);
                return Ok(new { message = $"Sản phẩm với ID {id} đã được xóa thành công." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Lấy tất cả sản phẩm
        [HttpGet("get-all")]
        public ActionResult<IEnumerable<SanPhamModel>> GetAllSanPhams()
        {
            try
            {
                var sanPhams = _sanPhamBL.GetAllSanPhams();
                return Ok(sanPhams);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }

        // Tìm kiếm sản phẩm với phân trang
        [HttpGet("search")]
        public ActionResult<IEnumerable<SanPhamModel>> SearchSanPhams(string keyword, int pageIndex, int pageSize)
        {
            try
            {
                long total;
                var sanPhams = _sanPhamBL.SearchSanPhams(keyword, pageIndex, pageSize, out total);
                return Ok(new { data = sanPhams, totalCount = total });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }
    }
}
