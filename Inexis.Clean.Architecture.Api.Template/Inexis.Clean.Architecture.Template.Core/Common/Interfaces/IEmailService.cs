using Inexis.Clean.Architecture.Template.Core.Common.Dtos;

namespace Inexis.Clean.Architecture.Template.Core.Common.Interfaces;

public interface IEmailService
{
    Task SendEmailByQueue(EmailModel email);

    Task<string> GetEmailTemplate(string emailTemplateName);
}
