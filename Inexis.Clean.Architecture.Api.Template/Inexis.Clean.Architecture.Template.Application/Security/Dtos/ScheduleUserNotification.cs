namespace Inexis.Clean.Architecture.Template.Application.Security.Dtos;

public sealed record ScheduleUserNotification(string NotificationType, bool IsActive, DateTimeOffset? Time);
