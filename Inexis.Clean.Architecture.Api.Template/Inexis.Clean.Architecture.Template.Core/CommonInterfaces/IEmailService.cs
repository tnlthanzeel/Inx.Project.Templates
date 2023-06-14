using Inexis.Clean.Architecture.Template.Core.CommonDtos;

namespace Inexis.Clean.Architecture.Template.Core.CommonInterfaces;

public interface IEmailService
{
    Task SendEmailByQueue(EmailModel email);

    Task<string> GetEmailTemplate(string emailTemplateName);
}
