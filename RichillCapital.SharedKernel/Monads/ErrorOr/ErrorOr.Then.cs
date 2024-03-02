namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Then(Action action)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TValue>();
        }

        action();

        return Value.ToErrorOr();
    }

    public ErrorOr<TValue> Then(Action<TValue> actionWithValue)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TValue>();
        }

        actionWithValue(Value);

        return Value.ToErrorOr();
    }

    public ErrorOr<TResult> Then<TResult>(Func<TResult> factory)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TResult>();
        }

        return factory().ToErrorOr();
    }

    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> factoryWithValue)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TResult>();
        }

        return factoryWithValue(Value).ToErrorOr();
    }

    public ErrorOr<TResult> Then<TResult>(Func<TValue, ErrorOr<TResult>> errorOrFactoryWithValue)
    {
        if (HasError)
        {
            return Errors
                .ToErrorOr<TResult>();
        }

        return errorOrFactoryWithValue(Value);
    }

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> errorOrFactoryWithValueTask)
    {
        if (HasError)
        {
            return Errors.ToErrorOr<TResult>();
        }

        return await errorOrFactoryWithValueTask(Value);
    }
}

public static partial class ErrorOrExtensions
{
    public static async Task<ErrorOr<TResult>> Then<TValue, TResult>(
        this Task<ErrorOr<TValue>> errorOrTask,
        Func<TValue, TResult> factoryWithValue)
    {
        var result = await errorOrTask;

        if (result.HasError)
        {
            return result.Errors.ToErrorOr<TResult>();
        }

        return factoryWithValue(result.Value).ToErrorOr();
    }
}