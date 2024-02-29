namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> ThrowIfError()
    {
        if (IsValue)
        {
            return Value.ToErrorOr();
        }

        throw new InvalidOperationException(Errors.First().Message);
    }
}