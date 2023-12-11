using Inexis.Clean.Architecture.Template.SharedKernal.Exceptions;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Responses;

public abstract class BaseResponse
{
    protected static BadRequestException _badRequestException = new();
    protected static NotFoundException _notFoundException = new();
    protected static OperationFailedException _operationFailedException = new();
    protected static UnauthorizedException _unauthorizedException = new();

    public bool Success { get; protected init; }

    public virtual List<KeyValuePair<string, IEnumerable<string>>> Errors { get; init; } = new();

    public BaseResponse()
    {
        Success = false;
    }
}
