using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models.User;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Email
{
    public static class EmailService
    {
        public static SendGridClient client;

        public static async Task<Response> SendMail<TMailType>(string userEmail, string userName, string userSurname) where TMailType : MailType
        {
            TMailType mailType = Activator.CreateInstance<TMailType>();

            var from = new EmailAddress("test@test.com", "Test test");
            var subject = mailType.subject;
            var to = new EmailAddress(userEmail, userName + " " + userSurname);
            var plainTextContent = mailType.plainTextContent;
            var htmlContent = mailType.htmlContent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            return await client.SendEmailAsync(msg);
        }
    }
}
