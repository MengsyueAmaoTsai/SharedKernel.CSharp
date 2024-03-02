namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> Then(Action action)
    {
        if (IsNull)
        {
            return Null;
        }

        action();

        return Value.ToMaybe();
    }

    public Maybe<TValue> Then(Action<TValue> actionWithValue)
    {
        if (IsNull)
        {
            return Null;
        }

        actionWithValue(Value);

        return Value.ToMaybe();
    }

    public Maybe<TResult> Then<TResult>(Func<TResult> factory)
    {
        if (IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return factory().ToMaybe();
    }

    public Maybe<TResult> Then<TResult>(Func<TValue, TResult> factoryWithValue)
    {
        if (IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return factoryWithValue(Value).ToMaybe();
    }
}

public static partial class MaybeExtensions
{
}