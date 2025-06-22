using GL.CompanyCatalog.Application.Models.Mail;

namespace GL.CompanyCatalog.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
