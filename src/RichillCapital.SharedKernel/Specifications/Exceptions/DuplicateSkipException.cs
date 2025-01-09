namespace RichillCapital.SharedKernel.Specifications.Exceptions;

public sealed class DuplicateSkipException : Exception
{
    private new const string Message =
        "Duplicate skip detected. Only one skip is allowed per specification.";

    public DuplicateSkipException()
        : base(Message)
    {
    }

    public DuplicateSkipException(Exception innerException)
        : base(Message, innerException)
    {
    }
}