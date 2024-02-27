namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> OrElse(TValue value) =>
        IsFailure ?
            Result<TValue>.Success(value) :
            Result<TValue>.Success(_value);
}

public readonly partial record struct Result
{
}