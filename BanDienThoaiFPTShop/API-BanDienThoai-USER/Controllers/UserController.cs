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
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBL.Login(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            }
            return Ok(new { taikhoan = user.TenTaiKhoan, email = user.Email, token = user.token });
        }


    }
}
