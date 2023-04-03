namespace Inexis.Clean.Architecture.Template.SharedKernal.Exceptions;

public sealed class UnauthorizedException : ApplicationException
{
    public UnauthorizedException(string message) : base(message)
    {
    }
}
