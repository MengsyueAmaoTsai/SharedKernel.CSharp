namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error)
    {
        if (!ensure(value))
        {
            return error.ToResult<TValue>();
        }

        return value.ToResult();
    }

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