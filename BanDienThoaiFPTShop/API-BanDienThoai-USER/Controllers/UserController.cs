using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DTO;

namespace API_BanDienThoai_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            this._userBL = userBL;
        }

        //Login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            try
            {
                var user = _userBL.Login(model.Username, model.Password);
                if (user == null)
                {
                    return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
                }
                return Ok(new { taikhoan = user.TenTaiKhoan, email = user.Email, token = user.token });
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }

        }

        //Đăng ký tài khoản
        [Route("DangKyTaiKhoan")]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            try
            {
                // Gọi BLL để thêm tài khoản
                _userBL.AddUser(userModel);
                return Ok("Đăng ký tài khoản thành công!");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        //Đổi mật khẩu
        [HttpPost("DoiMatKhau")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            try
            {
                bool success = _userBL.ChangePassword(model.TenTaiKhoan, model.MatKhauCu, model.MatKhauMoi);
                if (success)
                {
                    return Ok("Đổi mật khẩu thành công!");
                }
                else
                {
                    return BadRequest("Đổi mật khẩu thất bại! Vui lòng kiểm tra lại thông tin.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi thay đổi mật khẩu: " + ex.Message);
            }
        }

        //Quên mật khẩu
        [HttpPost("QuenMatKhau")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            try
            {
                string password;
                bool success = _userBL.ForgotPassword(model.Email, out password);
                if (success)
                {
                    return Ok($"Mật khẩu của bạn là: {password}");
                }
                else
                {
                    return NotFound("Email không tồn tại trong hệ thống.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi lấy lại mật khẩu: " + ex.Message);
            }
        }

        public class ChangePasswordModel
        {
            public string TenTaiKhoan { get; set; }
            public string MatKhauCu { get; set; }
            public string MatKhauMoi { get; set; }
        }

        public class ForgotPasswordModel
        {
            public string Email { get; set; }
        }
    }
}
