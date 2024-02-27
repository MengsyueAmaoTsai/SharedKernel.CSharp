namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public void Switch(
        Action<IEnumerable<Error>> onIsError,
        Action<TValue> onIsValue)
    {
        if (IsError)
        {
            onIsError(Errors);
        }
        else
        {
            onIsValue(Value);
        }
    }
}