namespace RichillCapital.SharedKernel.Specifications.Exceptions;

public sealed class ConcurrentSelectorsException : Exception
{
    private new const string Message =
        "Concurrent specification selector transforms defined." +
        "Ensure only one of the Select() or SelectMany() transforms is used in the same specification!";

    public ConcurrentSelectorsException()
        : base(Message)
    {
    }

    public ConcurrentSelectorsException(Exception innerException)
        : base(Message, innerException)
    {
    }
}