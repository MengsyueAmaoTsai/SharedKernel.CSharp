namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Then(Action action)
    {
        if (IsFailure)
        {
            return Error.ToResult<TValue>();
        }

        action();

        return Value.ToResult();
    }

    public Result<TValue> Then(Action<TValue> actionWithValue)
    {
        if (IsFailure)
        {
            return Error.ToResult<TValue>();
        }

        actionWithValue(Value);

        return Value.ToResult();
    }

    public Result<TResult> Then<TResult>(Func<TResult> factory)
    {
        if (IsFailure)
        {
            return Error.ToResult<TResult>();
        }

        return factory().ToResult();
    }

    public Result<TResult> Then<TResult>(Func<TValue, TResult> factoryWithValue)
    {
        if (IsFailure)
        {
            return Error.ToResult<TResult>();
        }

        return factoryWithValue(Value).ToResult();
    }
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
}