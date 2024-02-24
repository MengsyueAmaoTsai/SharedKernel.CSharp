namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public new Result<TValue> Then(Action action)
    {
        if (IsFailure)
        {
            return Result<TValue>.Failure(Error);
        }

        action();

        return Result<TValue>.Success(Value);
    }
}

public readonly partial record struct Result
{
    public Result Then(Action action)
    {
        if (IsFailure)
        {
            return Failure(Error);
        }

        action();

        return Success();
    }
}