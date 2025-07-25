using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using DemoMVC.Models.Process;

namespace DemoMVC.Models.Process
{
    public class SendMailService : IEmailSender
    {
        private readonly MailSettings mailSettings;
        private readonly ILogger<SendMailService> logger;

        public SendMailService(IOptions<MailSettings> _mailSettings, ILogger<SendMailService> _logger)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Create SendMailService");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(message);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, lưu nội dung email vào thư mục "mailsSave"
                System.IO.Directory.CreateDirectory("mailsSave");
                var emailSaveFile = string.Format(@"mailsSave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailSaveFile);

                logger.LogInformation("Lỗi gửi mail, lưu tại – " + emailSaveFile);
                logger.LogError(ex.Message);
            }

            smtp.Disconnect(true);
            logger.LogInformation("send mail to: " + email);
        }
    }
}
