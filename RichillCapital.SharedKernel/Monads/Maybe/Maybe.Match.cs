namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public TResult Match<TResult>(
        Func<TValue, TResult> onValue,
        Func<TResult> onNull) =>
        IsNull ?
            onNull() :
            onValue(Value);

}

public static partial class MaybeExtensions
{
    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Maybe<TValue>> maybeTask,
        Func<TValue, TResult> onHasValue,
        Func<TResult> onNull)
    {
        var maybe = await maybeTask;

        return maybe.Match(onHasValue, onNull);
    }
}