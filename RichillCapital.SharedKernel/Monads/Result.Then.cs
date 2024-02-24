namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Then(Action action)
    {
        if (IsFailure)
        {
            return Result<TValue>.Failure(Error);
        }

        action();

        return Result<TValue>.Success(Value);
    }

    // Un test
    public Result<TResult> Then<TResult>(Func<TResult> func)
    {
        if (IsFailure)
        {
            return Result<TResult>.Failure(Error);
        }

        return Result<TResult>.Success(func());
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

    public Result<TResult> Then<TResult>(Func<TResult> func)
    {
        if (IsFailure)
        {
            return Result<TResult>.Failure(Error);
        }

        return Result<TResult>.Success(func());
    }
}