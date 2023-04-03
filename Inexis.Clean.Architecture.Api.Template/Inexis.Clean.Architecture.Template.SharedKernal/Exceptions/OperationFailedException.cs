namespace Inexis.Clean.Architecture.Template.SharedKernal.Exceptions;

public sealed class OperationFailedException : ApplicationException
{
    public string PropertyName;

    public OperationFailedException(string propertyName, string message)
        : base(message)
    {
        PropertyName = propertyName;
    }
}
