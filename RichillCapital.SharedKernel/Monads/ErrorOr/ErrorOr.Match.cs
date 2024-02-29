namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public TResult Match<TResult>(
        Func<IEnumerable<Error>, TResult> onError,
        Func<TValue, TResult> onValue) =>
        HasError ?
            onError(Errors) :
            onValue(Value);
}

public static partial class ErrorOrExtensions
{
    public static async Task<TResult> Match<TValue, TResult>(
        this Task<ErrorOr<TValue>> errorOrTask,
        Func<IEnumerable<Error>, TResult> onError,
        Func<TValue, TResult> onValue)
    {
        var errorOr = await errorOrTask;

        return errorOr.Match(onError, onValue);
    }
}
