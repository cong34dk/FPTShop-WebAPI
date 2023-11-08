using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanDienThoai_ADMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServiceBL _emailService;

        public EmailController(IEmailServiceBL emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromQuery] EmailModel emailModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _emailService.SendEmailAsync(emailModel);
                return Ok(new { message = "Email sent successfully!" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while sending the email: {ex.Message}" });
            }
        }
    }
}
