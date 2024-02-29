namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> Else(TValue valueOnFailure)
    {
        if (IsFailure)
        {
            return valueOnFailure.ToResult();
        }

        return _value.ToResult();
    }
}