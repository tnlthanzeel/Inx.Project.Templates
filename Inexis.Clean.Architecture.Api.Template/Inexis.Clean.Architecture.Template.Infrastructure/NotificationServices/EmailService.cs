using Inexis.Clean.Architecture.Template.Application.CommonDtos;
using Inexis.Clean.Architecture.Template.Application.CommonInterfaces;

namespace Inexis.Clean.Architecture.Template.Infrastructure.NotificationServices;

public sealed class EmailService : IEmailService
{
    public Task<string> GetEmailTemplate(string emailTemplateName)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailByQueue(EmailModel email)
    {
        throw new NotImplementedException();
    }
}
