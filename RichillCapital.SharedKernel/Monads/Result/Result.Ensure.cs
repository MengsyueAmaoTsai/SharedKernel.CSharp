namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Ensure(
        Func<TValue, bool> ensure,
        Error error) =>
        IsFailure ?
            Result<TValue>.Failure(_error) :
            ensure(_value) ?
                Result<TValue>.Success(_value) :
                Result<TValue>.Failure(error);

    public Result<TValue> Ensure(
        (Func<TValue, bool> predicate, Error error) ensure) =>
        Ensure(ensure.predicate, ensure.error);
}

public readonly partial record struct Result
{
}