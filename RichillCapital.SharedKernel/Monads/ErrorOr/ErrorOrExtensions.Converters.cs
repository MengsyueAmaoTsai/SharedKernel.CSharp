namespace RichillCapital.SharedKernel.Monads;

public static partial class ErrorOr
{
    public static ErrorOr<TValue> ToErrorOr<TValue>(this TValue value)
    {
        return ErrorOr<TValue>.With(value);
    }
}