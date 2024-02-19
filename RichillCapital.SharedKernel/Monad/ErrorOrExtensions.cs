namespace RichillCapital.SharedKernel.Monad;

public static class ErrorOrExtensions
{
    public static ErrorOr<TValue> Then<TValue>(this ErrorOr<TValue> errorOr, Func<TValue> func) =>
        errorOr.IsError ?
            errorOr.Error :
            func();

    public static ErrorOr<TNewValue> Then<TValue, TNewValue>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, TNewValue> func) =>
        errorOr.IsError ?
            errorOr.Error :
            func(errorOr.Value);

    public static ErrorOr<TDestination> Map<TSource, TDestination>(
        this ErrorOr<TSource> errorOr,
        Func<TSource, TDestination> map) =>
        errorOr.IsError ?
            errorOr.Error :
            map(errorOr.Value);

    public static ErrorOr<TValue> ThrowIfError<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.IsError ?
            throw new InvalidOperationException(errorOr.Error.Message) :
            errorOr;

    public static ErrorOr<TValue> ThrowIfError<TValue>(this ErrorOr<TValue> errorOr, string message) =>
        errorOr.IsError ?
            throw new InvalidOperationException(message) :
            errorOr;

    public static ErrorOr<TValue> ThrowIfError<TValue>(this ErrorOr<TValue> errorOr, Error error) =>
        errorOr.IsError ?
            throw new InvalidOperationException(error.Message) :
            errorOr;

    public static ErrorOr ThrowIfError(this ErrorOr errorOr) =>
        errorOr.IsError ?
            throw new InvalidOperationException(errorOr.Error.Message) :
            errorOr;

    public static ErrorOr ThrowIfError(this ErrorOr errorOr, string message) =>
        errorOr.IsError ?
            throw new InvalidOperationException(message) :
            errorOr;

    public static ErrorOr ThrowIfError(this ErrorOr errorOr, Error error) =>
        errorOr.IsError ?
            throw new InvalidOperationException(error.Message) :
            errorOr;
}