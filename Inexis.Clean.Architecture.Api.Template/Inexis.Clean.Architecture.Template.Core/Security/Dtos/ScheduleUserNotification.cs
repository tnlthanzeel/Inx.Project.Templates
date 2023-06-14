namespace Inexis.Clean.Architecture.Template.Core.Security.Dtos;

public sealed record ScheduleUserNotification(string NotificationType, bool IsActive, DateTimeOffset? Time);
