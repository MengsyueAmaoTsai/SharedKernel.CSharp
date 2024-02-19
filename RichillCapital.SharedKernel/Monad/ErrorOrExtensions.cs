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

    public static void ThrowIfError(this ErrorOr errorOr)
    {
        if (errorOr.IsError)
        {
            throw new InvalidOperationException(errorOr.Error.Message);
        }
    }
}