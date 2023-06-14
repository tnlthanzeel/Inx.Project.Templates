using Inexis.Clean.Architecture.Template.Core.Common.Dtos;
using Inexis.Clean.Architecture.Template.Core.Common.Interfaces;

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
