namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Else(TValue elseValue)
    {
        if (IsFailure)
        {
            return elseValue.ToResult();
        }

        return Value.ToResult();
    }
}

public readonly partial record struct Result
{
}