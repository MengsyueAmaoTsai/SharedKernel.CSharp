namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Else(TValue elseValue)
    {
        if (IsNull)
        {
            return elseValue.ToMaybe();
        }

        return Value.ToMaybe();
    }
}

public static partial class MaybeExtensions
{
}