namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
}

public static partial class MaybeExtensions
{
    public static Maybe<TValue> Then<TValue>(
        this Maybe<TValue> maybe,
        Action action)
    {
        if (maybe.IsNull)
        {
            return Maybe<TValue>.Null;
        }

        action();

        return maybe.Value.ToMaybe();
    }

    public static Maybe<TValue> Then<TValue>(
        this Maybe<TValue> maybe,
        Action<TValue> actionWithValue)
    {
        if (maybe.IsNull)
        {
            return Maybe<TValue>.Null;
        }

        actionWithValue(maybe.Value);

        return maybe.Value.ToMaybe();
    }

    public static Maybe<TResult> Then<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TResult> factory)
    {
        if (maybe.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return factory().ToMaybe();
    }

    public static Maybe<TResult> Then<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, TResult> factoryWithValue)
    {
        if (maybe.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return factoryWithValue(maybe.Value).ToMaybe();
    }

    public static async Task<Maybe<TResult>> Then<TValue, TResult>(
        this Maybe<TValue> result,
        Func<TValue, Task<TResult>> factoryWithValueTask)
    {
        if (result.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        var resultValue = await factoryWithValueTask(result.Value);

        return resultValue.ToMaybe();
    }

    public static Maybe<TResult> Then<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, Maybe<TResult>> maybeFactoryWithValue)
    {
        if (maybe.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return maybeFactoryWithValue(maybe.Value);
    }

    public static async Task<Maybe<TResult>> Then<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, Task<Maybe<TResult>>> maybeFactoryWithValueTask)
    {
        if (maybe.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        return await maybeFactoryWithValueTask(maybe.Value);
    }

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

    public static async Task<Maybe<TResult>> Then<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, Task<Result<TResult>>> resultFactoryWithValueTask)
    {
        if (maybe.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        var result = await resultFactoryWithValueTask(maybe.Value);

        return result.ToMaybe();
    }

    public static async Task<Maybe<TResult>> Then<TValue, TResult>(
        this Maybe<TValue> maybe,
        Func<TValue, Task<ErrorOr<TResult>>> errorOrFactoryWithValueTask)
    {
        if (maybe.IsNull)
        {
            return Maybe<TResult>.Null;
        }

        var errorOr = await errorOrFactoryWithValueTask(maybe.Value);

        return errorOr.ToMaybe();
    }
}