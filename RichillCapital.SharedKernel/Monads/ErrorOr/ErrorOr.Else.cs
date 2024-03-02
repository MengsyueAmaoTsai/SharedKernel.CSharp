namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Else(TValue elseValue)
    {
        if (HasError)
        {
            return elseValue.ToErrorOr();
        }

        return Value.ToErrorOr();
    }
}