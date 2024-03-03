using Donton.Common.RequestResponses.Requests;
using Donton.Common.RequestResponses.Responses;

namespace Donton.DataAccess.DataService
{
    public interface IEmailService
    {
        Task<EmailResponse> SendMail(SendMailRequest req);
    }
}