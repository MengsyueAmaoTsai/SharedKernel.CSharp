namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public static Result<TValue> Success(TValue value) => new(value);

    public static Result<TValue> Failure(Error error) => new(error);
}

public readonly partial record struct Result
{
    public static Result Success() => new(true, Error.Null);

    public static Result Failure(Error error) => new(error);
}