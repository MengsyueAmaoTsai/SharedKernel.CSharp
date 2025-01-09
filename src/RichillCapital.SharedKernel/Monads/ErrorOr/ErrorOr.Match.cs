namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
}

public static partial class ErrorOrExtensions
{
    public static TResult Match<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<IEnumerable<Error>, TResult> onHasError,
        Func<TValue, TResult> onIsValue)
    {
        if (errorOr.HasError)
        {
            return onHasError(errorOr.Errors);
        }

        return onIsValue(errorOr.Value);
    }

    public static async Task<TResult> Match<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<IEnumerable<Error>, Task<TResult>> onHasErrorTask,
        Func<TValue, Task<TResult>> onIsValueTask)
    {
        if (errorOr.HasError)
        {
            return await onHasErrorTask(errorOr.Errors);
        }

        return await onIsValueTask(errorOr.Value);
    }

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<ErrorOr<TValue>> errorOrTask,
        Func<IEnumerable<Error>, TResult> onHasError,
        Func<TValue, TResult> onIsValue)
    {
        var errorOr = await errorOrTask;
        return errorOr.Match(onHasError, onIsValue);
    }
}