namespace RichillCapital.SharedKernel.Monads;

public static partial class ErrorOr
{
    public static ErrorOr<TValue> ToErrorOr<TValue>(this TValue value)
    {
        return ErrorOr<TValue>.With(value);
    }

    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this Task<TValue> valueTask)
    {
        var value = await valueTask;
        return ErrorOr<TValue>.With(value);
    }

    public static async ValueTask<ErrorOr<TValue>> ToErrorOr<TValue>(this ValueTask<TValue> valueTask)
    {
        var value = await valueTask;
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

    public static ErrorOr<TValue> ToErrorOr<TValue>(this Result<TValue> result) =>
        result.IsFailure ?
            ErrorOr<TValue>.WithError(result.Error) :
            ErrorOr<TValue>.With(result.Value);

    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this Task<Result<TValue>> resultTask)
    {
        var result = await resultTask;

        return result.IsFailure ?
            ErrorOr<TValue>.WithError(result.Error) :
            ErrorOr<TValue>.With(result.Value);
    }

    public static ErrorOr<TValue> ToErrorOr<TValue>(this Maybe<TValue> maybe, Error error) =>
        maybe.IsNull ?
            ErrorOr<TValue>.WithError(error) :
            ErrorOr<TValue>.With(maybe.Value);

    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this Task<Maybe<TValue>> maybeTask, Error error)
    {
        var maybe = await maybeTask;

        return maybe.IsNull ?
            ErrorOr<TValue>.WithError(error) :
            ErrorOr<TValue>.With(maybe.Value);
    }
}