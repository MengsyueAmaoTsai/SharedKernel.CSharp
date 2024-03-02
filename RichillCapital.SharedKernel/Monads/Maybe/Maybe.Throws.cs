namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    public static Maybe<TValue> ThrowIfNull<TValue>(this Maybe<TValue> maybe) =>
        maybe.IsNull ?
           throw new InvalidOperationException($"Maybe<{typeof(TValue)}> is null.") :
           maybe;

    public static async Task<Maybe<TValue>> ThrowIfNull<TValue>(
        this Task<Maybe<TValue>> maybeTask)
    {
        var maybe = await maybeTask;

        return maybe.ThrowIfNull();
    }
}