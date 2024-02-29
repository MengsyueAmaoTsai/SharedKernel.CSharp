namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public Maybe<TValue> ThrowIfNull(Error error)
    {
        if (HasValue)
        {
            return Value.ToMaybe();
        }

        // Default
        throw new InvalidOperationException(error.Message);
    }
}