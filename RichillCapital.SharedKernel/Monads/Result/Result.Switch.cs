namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public void Switch(
        Action<TValue> onSuccess,
        Action<Error> onFailure)
    {
        if (IsFailure)
        {
            onFailure(Error);
        }
        else
        {
            onSuccess(Value);
        }
    }
}

public readonly partial record struct Result
{
}