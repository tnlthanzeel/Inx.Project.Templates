namespace Inexis.Clean.Architecture.Template.SharedKernal.Exceptions;

public sealed class BadRequestException : ApplicationException
{
    public string? PropertyName;

    internal BadRequestException() { }

    public BadRequestException(string propertyName, string message) : base(message)
    {
        PropertyName = propertyName;
    }
}