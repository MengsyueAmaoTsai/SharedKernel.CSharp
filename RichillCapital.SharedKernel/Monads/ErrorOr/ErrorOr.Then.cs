namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> resultFactory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            resultFactory(Value).ToErrorOr();

    public ErrorOr<TResult> Then<TResult>(Func<TResult> resultFactory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            resultFactory().ToErrorOr();

    public ErrorOr<TValue> Then(Action<TValue> action)
    {
        if (HasError)
        {
            return Errors.ToErrorOr<TValue>();
        }

        action(Value);

        return Value.ToErrorOr();
    }

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> errorOrFactoryTask) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            await errorOrFactoryTask(Value).ConfigureAwait(false);
}
