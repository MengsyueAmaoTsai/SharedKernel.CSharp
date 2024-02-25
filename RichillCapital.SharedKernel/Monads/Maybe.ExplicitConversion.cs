namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    public static Maybe<TValue> ToMaybe<TValue>(this TValue value) =>
        Maybe<TValue>.Have(value);
}