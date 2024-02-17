namespace RichillCapital.SharedKernel.Specifications.Exceptions;

public sealed class DuplicateTakeException : Exception
{
    private new const string Message =
        "Duplicate take clause detected. Only one take clause is allowed per specification.";

    public DuplicateTakeException()
        : base(Message)
    {
    }

    public DuplicateTakeException(Exception innerException)
        : base(Message, innerException)
    {
    }
}