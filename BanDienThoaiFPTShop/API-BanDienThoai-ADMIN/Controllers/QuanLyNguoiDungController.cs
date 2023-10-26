using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL.Interfaces;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DAL;
using BLL;

namespace API_BanDienThoai_ADMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyNguoiDungController : ControllerBase
    {
        private IUserBL _userBL;

        public QuanLyNguoiDungController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        //Lấy về tất cả user
        [Route("get-all-user")]
        [HttpGet]
        public List<UserModel> GetAllUsers()
        {
            return _userBL.GetAllUsers();
        }


        //Tạo tài khoản mới
        [Route("add-user")]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            try
            {
                // Gọi BLL để thêm tài khoản
                _userBL.AddUser(userModel);
                return Ok("Tài khoản đã được thêm thành công!");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        //Sửa tài khoản
        [Route("update-user/{id}")]
        [HttpPut]
        public IActionResult UpdateUser(int id, [FromBody] UserModel userModel)
        {
            try
            {
                userModel.MaTaiKhoan = id;
                var updatedUser = _userBL.UpdateUser(userModel);

                return Ok($"Đã cập nhật tài khoản với id là {id} thành công!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        //Xóa tài khoản
        [Route("delete-user/{id}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                bool isDeleted = _userBL.DeleteUser(id);
                if (!isDeleted)
                {
                    return Ok($"Đã xóa tài khoản với id {id} thành công!");
                }
                else
                {
                    return NotFound($"Không tìm thấy hoặc không thể xóa tài khoản với id {id}.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

    }
}


