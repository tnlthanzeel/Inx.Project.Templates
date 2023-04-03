using FluentValidation;
using Inexis.Clean.Architecture.Template.Application.Security.Dtos;
using VPMS.SharedKernel;

namespace Inexis.Clean.Architecture.Template.Application.Security.Validators;

public sealed class ScheduleUserNotificationValidator : AbstractValidator<ScheduleUserNotification>
{
    public ScheduleUserNotificationValidator()
    {
        When(w => w.IsActive is true, () =>
        {
            RuleFor(sn => sn.Time)
                    .NotEmpty().WithMessage("Invalid notification time");

            RuleFor(r => r.NotificationType)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("NotificationType is required")
                    .Must((model, notificationType) =>
                    {
                        var isValid = ApplicationNotificationTypes.DoesNotificationTypeExist(notificationType);
                        return isValid;
                    }).WithMessage("Invalid notification type");

        });

        When(w => w.IsActive is false, () =>
        {
            RuleFor(r => r.NotificationType)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("NotificationType is required")
                    .Must((model, notificationType) =>
                    {
                        var isValid = ApplicationNotificationTypes.DoesNotificationTypeExist(notificationType);
                        return isValid;
                    }).WithMessage("Invalid notification type");

        });
    }
}
