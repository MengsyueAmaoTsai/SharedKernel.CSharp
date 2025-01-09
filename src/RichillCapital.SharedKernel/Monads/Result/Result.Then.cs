namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
    public static Result<TValue> Then<TValue>(
        this Result<TValue> result,
        Action action)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TValue>();
        }

        action();

        return result.Value.ToResult();
    }

    public static Result<TValue> Then<TValue>(
        this Result<TValue> result,
        Action<TValue> actionWithValue)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TValue>();
        }

        actionWithValue(result.Value);

        return result.Value.ToResult();
    }

    public static Result<TResult> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TResult> factory)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        return factory().ToResult();
    }

    public static Result<TResult> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, TResult> factoryWithValue)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        return factoryWithValue(result.Value).ToResult();
    }

    public static async Task<Result<TResult>> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, Task<TResult>> factoryWithValueTask)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        var resultValue = await factoryWithValueTask(result.Value);

        return resultValue.ToResult();
    }

    public static Result<TResult> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, Result<TResult>> resultFactoryWithValue)
    {
        if (result.IsFailure)
        {
            return result.Error
                .ToResult<TResult>();
        }

        return resultFactoryWithValue(result.Value);
    }

    public static async Task<Result<TResult>> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, Task<Result<TResult>>> resultFactoryWithValueTask)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        return await resultFactoryWithValueTask(result.Value);
    }

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

    public static async Task<Result<TResult>> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, Task<Maybe<TResult>>> maybeFactoryWithValueTask,
        Func<TValue, Error> errorFactoryWithValue)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        var maybe = await maybeFactoryWithValueTask(result.Value);

        return maybe.ToResult(errorFactoryWithValue(result.Value));
    }

    public static async Task<Result<TResult>> Then<TValue, TResult>(
        this Result<TValue> result,
        Func<TValue, Task<ErrorOr<TResult>>> errorOrFactoryWithValueTask)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        var errorOr = await errorOrFactoryWithValueTask(result.Value);

        return errorOr.ToResult();
    }
}