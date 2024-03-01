namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TResult> Then<TResult>(Func<TValue, TResult> factory) =>
        IsNull ?
            Maybe<TResult>.Null :
            factory(Value).ToMaybe();

    public Maybe<TValue> Then(Action<TValue> action)
    {
        if (IsNull)
        {
            return Null;
        }

        action(Value);
        return Value.ToMaybe();
    }

    public async Task<Maybe<TValue>> Then(Func<Task> task)
    {
        if (IsNull)
        {
            return Null;
        }

        await task();
        return Value.ToMaybe();
    }
}