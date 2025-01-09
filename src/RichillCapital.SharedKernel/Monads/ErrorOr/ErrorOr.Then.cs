namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
}

public static partial class ErrorOrExtensions
{
    public static ErrorOr<TValue> Then<TValue>(
        this ErrorOr<TValue> errorOr,
        Action action)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors
                .ToErrorOr<TValue>();
        }

        action();

        return errorOr.Value.ToErrorOr();
    }

    public static ErrorOr<TValue> Then<TValue>(
        this ErrorOr<TValue> errorOr,
        Action<TValue> actionWithValue)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors
                .ToErrorOr<TValue>();
        }

        actionWithValue(errorOr.Value);

        return errorOr.Value.ToErrorOr();
    }

    public static ErrorOr<TResult> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TResult> factory)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors
                .ToErrorOr<TResult>();
        }

        return factory().ToErrorOr();
    }

    public static ErrorOr<TResult> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, TResult> factoryWithValue)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors
                .ToErrorOr<TResult>();
        }

        return factoryWithValue(errorOr.Value).ToErrorOr();
    }

    public static async Task<ErrorOr<TResult>> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, Task<TResult>> factoryWithValueTask)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors.ToErrorOr<TResult>();
        }

        var result = await factoryWithValueTask(errorOr.Value);

        return result.ToErrorOr();
    }

    public static ErrorOr<TResult> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, ErrorOr<TResult>> errorOrFactoryWithValue)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors
                .ToErrorOr<TResult>();
        }

        return errorOrFactoryWithValue(errorOr.Value);
    }

    public static async Task<ErrorOr<TResult>> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, Task<ErrorOr<TResult>>> errorOrFactoryWithValueTask)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors.ToErrorOr<TResult>();
        }

        return await errorOrFactoryWithValueTask(errorOr.Value);
    }

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

    public static async Task<ErrorOr<TResult>> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, Task<Maybe<TResult>>> maybeFactoryWithValueTask,
        Func<TValue, Error> errorFactoryWithValue)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors.ToErrorOr<TResult>();
        }

        var maybe = await maybeFactoryWithValueTask(errorOr.Value);

        return maybe.ToErrorOr(errorFactoryWithValue(errorOr.Value));
    }

    public static async Task<ErrorOr<TResult>> Then<TValue, TResult>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, Task<Result<TResult>>> resultFactoryWithValueTask)
    {
        if (errorOr.HasError)
        {
            return errorOr.Errors.ToErrorOr<TResult>();
        }

        var result = await resultFactoryWithValueTask(errorOr.Value);

        return result.ToErrorOr();
    }
}