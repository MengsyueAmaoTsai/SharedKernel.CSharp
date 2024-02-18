namespace RichillCapital.SharedKernel.Monad;

public static class MaybeExtensions
{
    public static Maybe<TDestination> Map<TSource, TDestination>(
        this Maybe<TSource> maybe,
        Func<TSource, TDestination> map) =>
        maybe.HasValue ?
            map(maybe.Value) :
            Maybe<TDestination>.Null;

    public static void ThrowIfNoValue<TValue>(this Maybe<TValue> maybe)
    {
        if (maybe.HasNoValue)
        {
            throw new InvalidOperationException("Maybe does not have a value");
        }
    }
}