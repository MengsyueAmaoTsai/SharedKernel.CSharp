namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> factory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            factory(Value).ToErrorOr();

    public ErrorOr<TValue> Then(Action<TValue> action)
    {
        if (HasError)
        {
            return Errors.ToErrorOr<TValue>();
        }

        action(Value);
        return Value.ToErrorOr();
    }

    public async Task<ErrorOr<TValue>> Then(Func<Task> task)
    {
        if (HasError)
        {
            return Errors.ToErrorOr<TValue>();
        }

        await task();
        return Value.ToErrorOr();
    }
}

public static partial class ErrorOrExtensions
{
    public static async Task<ErrorOr<TResult>> Then<TValue, TResult>(
        this Task<ErrorOr<TValue>> errorOrTask,
        Func<TValue, TResult> factory)
    {
        var errorOr = await errorOrTask;
        return errorOr.Then(factory);
    }
}