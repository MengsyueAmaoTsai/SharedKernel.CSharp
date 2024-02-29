namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public Result<TValue> ThrowIfFailure()
    {
        if (IsSuccess)
        {
            return Value.ToResult();
        }

        throw new InvalidOperationException(Error.Message);
    }
}