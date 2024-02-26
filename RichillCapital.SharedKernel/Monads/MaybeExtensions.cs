namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    public static async Task<Maybe<TResult>> Map<TValue, TResult>(
    this Task<Maybe<TValue>> maybeTask,
    Func<TValue, TResult> map)
    {
        var maybeResult = await maybeTask;

        return maybeResult.HasNoValue ?
            Maybe<TResult>.Null :
            Maybe<TResult>.Have(map(maybeResult.Value));
    }

    public static async Task<TResult> Match<TValue, TResult>(
        this Task<Maybe<TValue>> errorOrTask,
        Func<TValue, TResult> onHasValue,
        Func<TResult> onNoValue)
    {
        var errorOr = await errorOrTask;

        return errorOr.HasNoValue ?
            onNoValue() :
            onHasValue(errorOr.Value);
    }
}