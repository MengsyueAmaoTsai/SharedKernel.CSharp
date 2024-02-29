namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Then<TResult>(Func<TValue, TResult> resultFactory) =>
        IsFailure ?
            Error.ToResult<TResult>() :
            resultFactory(Value).ToResult();

    public Result<TResult> Then<TResult>(Func<TResult> resultFactory) =>
        IsFailure ?
            Error.ToResult<TResult>() :
            resultFactory().ToResult();

    public Result<TValue> Then(Action<TValue> action)
    {
        if (IsFailure)
        {
            return Error.ToResult<TValue>();
        }

        action(Value);

        return Value.ToResult();
    }

    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<Result<TResult>>> resultFactoryTask) =>
        IsFailure ?
            Error.ToResult<TResult>() :
            await resultFactoryTask(Value).ConfigureAwait(false);
}