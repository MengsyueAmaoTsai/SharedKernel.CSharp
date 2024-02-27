namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Then<TResult>(Func<TValue, Result<TResult>> onValue) =>
         IsFailure ?
             Result<TResult>.Failure(Error) :
             onValue(Value);

    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<Result<TResult>>> onValueTask) =>
        IsFailure ?
            Result<TResult>.Failure(Error) :
            await onValueTask(Value);

    public Result<TValue> Then(Action<TValue> onValue)
    {
        if (IsFailure)
        {
            return Result<TValue>.Failure(Error);
        }

        onValue(Value);

        return _value.ToResult();
    }

    public async Task<Result<TValue>> Then(Func<TValue, Task> onValueTask)
    {
        if (IsFailure)
        {
            return Result<TValue>.Failure(Error);
        }

        await onValueTask(Value);

        return _value.ToResult();
    }

    public Result<TResult> Then<TResult>(Func<TValue, TResult> onValue) =>
        IsFailure ?
            Result<TResult>.Failure(Error) :
            onValue(Value).ToResult();

    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<TResult>> onValueTask) =>
        IsFailure ?
            Result<TResult>.Failure(Error) :
            await onValueTask(Value).ToResult();
}

public readonly partial record struct Result
{
}