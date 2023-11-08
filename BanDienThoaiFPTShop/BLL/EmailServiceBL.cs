using DTO;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace BLL
{
    public interface IEmailServiceBL
    {
        Task SendEmailAsync(EmailModel emailModel);
    }

    public class EmailServiceBL : IEmailServiceBL
    {
        //IConfiguration là một interface lấy thông tin từ appsettings.json
        private readonly IConfiguration _configuration;

        public EmailServiceBL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(EmailModel emailModel)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("pcua0064@gmail.com", "FPT Shop");
            var to = new EmailAddress(emailModel.To);
            var msg = MailHelper.CreateSingleEmail(from, to, emailModel.Subject, emailModel.Body, emailModel.Body);
            //Gửi email đã tạo ra thông qua client của SendGrid.
            //Đây là một thao tác không đồng bộ, và await đảm bảo rằng
            //việc gửi email hoàn tất trước khi phương thức trả về.
            await client.SendEmailAsync(msg);
        }
    }
}
