namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TResult> Then<TResult>(Func<TValue, TResult> resultFactory)
    {
        if (IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return resultFactory(Value).ToMaybe();
    }
}