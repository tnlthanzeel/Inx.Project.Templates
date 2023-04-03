using Inexis.Clean.Architecture.Template.Application.CommonDtos;

namespace Inexis.Clean.Architecture.Template.Application.CommonInterfaces;

public interface IEmailService
{
    Task SendEmailByQueue(EmailModel email);

    Task<string> GetEmailTemplate(string emailTemplateName);
}
