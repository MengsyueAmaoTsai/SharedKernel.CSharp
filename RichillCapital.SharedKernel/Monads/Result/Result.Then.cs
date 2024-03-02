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

    // Untested
    public Result<TResult> Then<TResult>(Func<TValue, Result<TResult>> resultFactoryWithValue)
    {
        if (IsFailure)
        {
            return Error
                .ToResult<TResult>();
        }

        return resultFactoryWithValue(Value);
    }

    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<Result<TResult>>> resultFactoryWithValueTask)
    {
        if (IsFailure)
        {
            return Error.ToResult<TResult>();
        }

        return await resultFactoryWithValueTask(Value);
    }
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
    public static async Task<Result<TResult>> Then<TValue, TResult>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, TResult> factoryWithValue)
    {
        var result = await resultTask;

        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        return factoryWithValue(result.Value).ToResult();
    }
}