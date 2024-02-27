namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Map<TResult>(
        Func<TValue, TResult> map) =>
        IsFailure ?
            Result<TResult>.Failure(_error) :
            Result<TResult>.Success(map(_value));
}

public readonly partial record struct Result
{
}