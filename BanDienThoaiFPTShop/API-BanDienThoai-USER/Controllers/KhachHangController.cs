using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using BLL.Interfaces;
using DTO;

namespace API_BanDienThoai_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBL _khachHangBL;

        public KhachHangController(IKhachHangBL khachHangBL)
        {
            _khachHangBL = khachHangBL;
        }
        ////Thêm mới 1 khách hàng
        //[Route("create-khachhang")]
        //[HttpPost]
        //public IActionResult createKhachHang([FromBody] KhachHangModel model)
        //{
        //    try
        //    {
        //        _khachHangBL.InsertKhachHang(model.TenKh, model.GioiTinh, model.DiaChi, model.Sdt, model.Email);
        //        return Ok("Khách hàng đã được thêm thành công!");

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Lỗi: {ex.Message}");

        //    }
        //}
        ////Tìm kiếm mã khách hàng theo id
        //[Route("get-by-id/{id}")]
        //[HttpGet]
        //public KhachHangModel getById(int id)
        //{
        //    return _khachHangBL.getById(id);
        //}
        ////Update khách hàng
        //[Route("update-khachhang")]
        //[HttpPost]
        //public IActionResult updateKhachHang([FromBody] KhachHangModel model)
        //{
        //    try
        //    {
        //        _khachHangBL.upDateKhachHang(model.Id, model.TenKh, model.GioiTinh, model.DiaChi, model.Sdt, model.Email);
        //        return Ok("Đã update khách hàng thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Lỗi:{ex.Message}");
        //    }
        //}
        ////Xóa khách hàng theo mã id
        //[Route("delete-khachhang/{id}")]
        //[HttpDelete]
        //public IActionResult DeleteKhachHang(int id)
        //{
        //    try
        //    {
        //        _khachHangBL.deleteKhachHang(id);
        //        return Ok($"Khách hàng với Id {id} đã được xóa thành công");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Lỗi: {ex.Message}");
        //    }
        //}
        //[Route("search")]
        //[HttpPost]
        //public IActionResult Search([FromBody] Dictionary<string,object> fromData)
        //{
        //    try
        //    {
        //        var page = int.Parse(fromData["page"].ToString());
        //        var pageSize = int.Parse(fromData["pageSize"].ToString());
        //        string ten_khach="";
        //        if (fromData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(fromData["ten_khach"])))
        //        {
        //            ten_khach = Convert.ToString(fromData["ten_Khach"]);
        //        }
        //        string dia_chi = "";
        //        if (fromData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(fromData["dia_chi"])))
        //        { 
        //            dia_chi = Convert.ToString(fromData["dia_chi"]);
        //        }
        //        long total = 0;
        //        var data = _khachHangBL.searchKhachHang(page, pageSize, out total, ten_khach, dia_chi);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = page,
        //                PageSize = pageSize
        //            }
        //            );

        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}



    }
}
