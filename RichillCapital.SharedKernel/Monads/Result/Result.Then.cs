namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Then<TResult>(Func<TValue, TResult> resultFactory)
    {
        if (IsFailure)
        {
            return Error.ToResult<TResult>();
        }

        return resultFactory(Value).ToResult();
    }
}