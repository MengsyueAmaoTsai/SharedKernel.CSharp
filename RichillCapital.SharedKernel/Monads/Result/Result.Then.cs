namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Then<TResult>(Func<TValue, TResult> factory) =>
        IsFailure ?
            Error.ToResult<TResult>() :
            factory(Value).ToResult();

    public Result<TValue> Then(Action<TValue> action)
    {
        if (IsFailure)
        {
            return Error.ToResult<TValue>();
        }

        action(Value);
        return Value.ToResult();
    }
}

public readonly partial record struct Result
{
}