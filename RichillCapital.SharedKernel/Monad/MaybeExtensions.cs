namespace RichillCapital.SharedKernel.Monad;

public static class MaybeExtensions
{
    public static Maybe<TDestination> Map<TSource, TDestination>(
        this Maybe<TSource> maybe,
        Func<TSource, TDestination> map) =>
        maybe.HasValue ?
            map(maybe.Value) :
            Maybe<TDestination>.Null;

    public static Maybe<TValue> ThrowIfNoValue<TValue>(this Maybe<TValue> maybe) =>
        maybe.HasNoValue ?
            throw new InvalidOperationException("Maybe does not have a value") :
            maybe.Value;

    public static Maybe<TValue> ThrowIfNoValue<TValue>(this Maybe<TValue> maybe, string message) =>
        maybe.HasNoValue ?
            throw new InvalidOperationException(message) :
            maybe.Value;

    public static Maybe<TValue> ThrowIfNoValue<TValue>(this Maybe<TValue> maybe, Error error) =>
        maybe.HasNoValue ?
            throw new InvalidOperationException(error.Message) :
            maybe.Value;
}