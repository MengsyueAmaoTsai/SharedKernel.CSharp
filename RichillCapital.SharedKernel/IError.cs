namespace RichillCapital.SharedKernel;

public interface IError
{
    ErrorType Type { get; }

    string Message { get; }
}