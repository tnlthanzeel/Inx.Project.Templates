using Inexis.Clean.Architecture.Template.SharedKernal.Models;
using Inexis.Clean.Architecture.Template.SharedKernal.Responses;
using TimeZoneConverter;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Extensions;

public static class TimeZoneExtension
{
    private static readonly IReadOnlyList<TimeZoneModel> _timeZones = TimeZoneInfo.GetSystemTimeZones()
                                                    .Select(tz => new TimeZoneModel(tz.DisplayName, tz.Id)).ToList();

    public static ResponseResult<IReadOnlyList<TimeZoneModel>> GetAllTimeZone()
    {
        return new ResponseResult<IReadOnlyList<TimeZoneModel>>(_timeZones);
    }

    public static bool IsTimeZoneAvailable(string id)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(id);

        return timeZone is not null;
    }

    public static DateTimeOffset GetLocalTime(this DateTimeOffset dateTimeOffset, string timeZoneId)
    {
        TimeZoneInfo timeZone = TZConvert.GetTimeZoneInfo(timeZoneId);

        var clientdatetime = dateTimeOffset.ToOffset(timeZone.BaseUtcOffset);
        return clientdatetime;
    }
}
