namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onHasValue,
        Func<TResult> onIsNull) =>
        IsNull ?
            onIsNull() :
            onHasValue(Value);

    public async Task<TResult> Match<TResult>(
        Func<TValue, Task<TResult>> onHasValueTask,
        Func<Task<TResult>> onIsNullTask)
    {
        if (IsNull)
        {
            return await onIsNullTask();
        }

        return await onHasValueTask(Value);
    }
}

public static partial class MaybeExtensions
{
    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Maybe<TValue>> maybeTask,
        Func<TValue, TResult> onHasValue,
        Func<TResult> onIsNull)
    {
        var maybe = await maybeTask;
        return maybe.Match(onHasValue, onIsNull);
    }
}