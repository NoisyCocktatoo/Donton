using Donton.Common.Constants;
using Donton.Common.RequestResponses.Requests;
using Donton.Common.RequestResponses.Responses;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.DataAccess.DataService
{
    public class EmailService : IEmailService
    {
        private readonly IDataRepository repository_;
        private readonly SmtpClient client_;

        public EmailService(IDataRepository repository)
        {
            repository_ = repository;
            client_ = new SmtpClient();
        }

        private async Task<Donton.DataAccess.Models.EmailService> ClientConnect()
        {
            var mailSettingResult = await repository_.Context.EmailServices.FirstOrDefaultAsync(p => p.Domain == "donton");
            if (mailSettingResult != null)
            {
                client_.CheckCertificateRevocation = Convert.ToBoolean(mailSettingResult.CheckCertificateRevocation);
                client_.Connect(mailSettingResult.Smtp, Convert.ToInt16(mailSettingResult.Port), Convert.ToBoolean(mailSettingResult.UseSSL));
                client_.Authenticate(mailSettingResult.Username, mailSettingResult.Password);
            }
            return mailSettingResult;
        }

        public async Task<EmailResponse> SendMail(SendMailRequest req)
        {
            EmailResponse retValue = new();
            try
            {
                var mailSettingResult = await ClientConnect();
                if (mailSettingResult != null)
                {
                    var message = new MimeMessage();
                    req.FromEmail = mailSettingResult.Username;

                    var from = new MailboxAddress(req.SenderName, req.FromEmail);
                    message.From.Add(from);
                    foreach (var tos in req.ToEmails)
                    {
                        var to = new MailboxAddress(tos.Name, tos.Email);
                        message.To.Add(to);
                    }
                    foreach (var bcc in req.Bccs)
                    {
                        var to = new MailboxAddress(bcc.Name, bcc.Email);
                        message.Bcc.Add(to);
                    }
                    message.Subject = req.Subject;
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = req.Body;
                    message.Body = bodyBuilder.ToMessageBody();
                    await client_.SendAsync(message);
                }
            }
            catch (Exception ex)
            {
                retValue.ErrorMessage = ex.Message;
            }
            return retValue;
        }
    }
}
