using Inexis.Clean.Architecture.Template.Core.CommonDtos;
using Inexis.Clean.Architecture.Template.Core.CommonInterfaces;

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
