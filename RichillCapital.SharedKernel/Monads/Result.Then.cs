namespace RichillCapital.SharedKernel.Monads;

public sealed partial record class Result<TValue> : Result
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

public partial record class Result
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