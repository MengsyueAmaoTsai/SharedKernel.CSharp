namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public TResult Match<TResult>(
        Func<IEnumerable<Error>, TResult> onHasError,
        Func<TValue, TResult> onIsValue)
    {
        if (HasError)
        {
            return onHasError(Errors);
        }

        return onIsValue(Value);
    }

    public async Task<TResult> Match<TResult>(
        Func<IEnumerable<Error>, Task<TResult>> onHasErrorTask,
        Func<TValue, Task<TResult>> onIsValueTask)
    {
        if (HasError)
        {
            return await onHasErrorTask(Errors);
        }

        return await onIsValueTask(Value);
    }
}

public static partial class ErrorOrExtensions
{
    public static async Task<TResult> Match<TValue, TResult>(
        this Task<ErrorOr<TValue>> errorOrTask,
        Func<IEnumerable<Error>, TResult> onHasError,
        Func<TValue, TResult> onIsValue)
    {
        var errorOr = await errorOrTask;
        return errorOr.Match(onHasError, onIsValue);
    }
}