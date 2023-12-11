using System.Diagnostics;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Responses;

public sealed class ErrorResponse : BaseResponse
{
    public string TraceId { get; } = Activity.Current?.Id ?? "N/A";

    public ErrorResponse()
    {
        Success = false;
    }
}
