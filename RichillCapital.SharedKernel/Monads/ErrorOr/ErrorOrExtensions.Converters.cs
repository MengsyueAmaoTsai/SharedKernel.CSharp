namespace RichillCapital.SharedKernel.Monads;

public static partial class ErrorOr
{
    public static ErrorOr<TValue> ToErrorOr<TValue>(this TValue value)
    {
        return ErrorOr<TValue>.With(value);
    }

    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error error)
    {
        return ErrorOr<TValue>.WithError(error);
    }

    public static ErrorOr<TValue> ToErrorOr<TValue>(this List<Error> errors)
    {
        return ErrorOr<TValue>.WithError(errors);
    }

    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error[] errors)
    {
        return ErrorOr<TValue>.WithError(errors);
    }
}