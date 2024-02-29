namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TResult> Then<TResult>(Func<TValue, TResult> valueFactory)
    {
        if (IsFailure)
        {
            return Error.ToResult<TResult>();
        }

        var value = valueFactory(Value);

        return value.ToResult();
    }
}