namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Else(TValue valueOnNull)
    {
        if (IsNull)
        {
            return valueOnNull.ToMaybe();
        }

        return _value.ToMaybe();
    }
}