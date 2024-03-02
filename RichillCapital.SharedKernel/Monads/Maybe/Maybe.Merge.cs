namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
}

public static partial class MaybeExtensions
{
    public static Maybe<TValue> Merge<TValue>(
        this Maybe<TValue> maybe,
        params Maybe<TValue>[] maybes) =>
        maybe.IsNull ?
            Maybe<TValue>.Null :
            maybes.Any(maybe => maybe.IsNull) ?
                Maybe<TValue>.Null :
                maybes.Last().Value.ToMaybe();
}