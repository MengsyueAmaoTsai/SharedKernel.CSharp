namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Else(TValue valueOnError)
    {
        if (HasError)
        {
            return valueOnError.ToErrorOr();
        }

        return _value.ToErrorOr();
    }
}