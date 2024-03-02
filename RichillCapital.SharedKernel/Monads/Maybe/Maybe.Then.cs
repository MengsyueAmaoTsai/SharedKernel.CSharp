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

    // Untested
    public Maybe<TResult> Then<TResult>(Func<TValue, Maybe<TResult>> maybeFactoryWithValue)
    {
        if (IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return maybeFactoryWithValue(Value);
    }

    public async Task<Maybe<TResult>> Then<TResult>(Func<TValue, Task<Maybe<TResult>>> maybeFactoryWithValueTask)
    {
        if (IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return await maybeFactoryWithValueTask(Value);
    }
}

public static partial class MaybeExtensions
{
    public static async Task<Maybe<TResult>> Then<TValue, TResult>(
        this Task<Maybe<TValue>> maybeTask,
        Func<TValue, TResult> factoryWithValue)
    {
        var result = await maybeTask;

        if (result.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return factoryWithValue(result.Value).ToMaybe();
    }
}