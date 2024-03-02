namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
}

public static partial class MaybeExtensions
{
    public static Maybe<TValue> Else<TValue>(
        this Maybe<TValue> maybe,
        TValue elseValue)
    {
        if (maybe.IsNull)
        {
            return elseValue.ToMaybe();
        }

        return maybe.Value.ToMaybe();
    }
}