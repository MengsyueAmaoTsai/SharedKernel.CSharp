namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Ensure(
        Func<TValue, bool> ensure,
        Error error) =>
        IsFailure ?
            Error.ToResult<TValue>() :
            !ensure(Value) ?
                error.ToResult<TValue>() :
                Value.ToResult();
}

public readonly partial record struct Result
{
}