namespace RichillCapital.SharedKernel.Specifications.Exceptions;

public class InvalidSearchPatternException : Exception
{
    private new const string Message = "Invalid search pattern: ";

    public InvalidSearchPatternException(string searchPattern)
        : base($"{Message}{searchPattern}")
    {
    }

    public InvalidSearchPatternException(
        string searchPattern,
        Exception innerException)
        : base($"{Message}{searchPattern}", innerException)
    {
    }
}