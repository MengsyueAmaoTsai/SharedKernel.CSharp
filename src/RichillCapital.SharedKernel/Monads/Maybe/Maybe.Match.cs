namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
}

public static partial class MaybeExtensions
{
    public static TResult Match<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, TResult> onHasValue,
        Func<TResult> onIsNull) =>
        maybe.IsNull ?
            onIsNull() :
            onHasValue(maybe.Value);

    public static async Task<TResult> Match<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, Task<TResult>> onHasValueTask,
        Func<Task<TResult>> onIsNullTask)
    {
        if (maybe.IsNull)
        {
            return await onIsNullTask();
        }

        return await onHasValueTask(maybe.Value);
    }

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Maybe<TValue>> maybeTask,
        Func<TValue, TResult> onHasValue,
        Func<TResult> onIsNull)
    {
        var maybe = await maybeTask;
        return maybe.Match(onHasValue, onIsNull);
    }
}