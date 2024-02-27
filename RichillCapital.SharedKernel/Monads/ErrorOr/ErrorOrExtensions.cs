namespace RichillCapital.SharedKernel.Monads;

public static partial class ErrorOrExtensions
{
    public static async Task<ErrorOr<TResult>> Map<TValue, TResult>(
    this Task<ErrorOr<TValue>> errorOrTask,
    Func<TValue, TResult> map)
    {
        var errorOr = await errorOrTask;

        return errorOr.IsError ?
            ErrorOr<TResult>.Is(errorOr.ErrorsOrEmpty) :
            ErrorOr<TResult>.Is(map(errorOr.Value));
    }

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<ErrorOr<TValue>> errorOrTask,
        Func<IEnumerable<Error>, TResult> onIsError,
        Func<TValue, TResult> onIsValue)
    {
        var errorOr = await errorOrTask;

        return errorOr.IsError ?
            onIsError(errorOr.ErrorsOrEmpty) :
            onIsValue(errorOr.Value);
    }
}