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
            return;
        }

        onIsValue(Value);
    }

    public async Task Switch(
        Func<IEnumerable<Error>, Task> onIsError,
        Func<TValue, Task> onIsValue)
    {
        if (IsError)
        {
            await onIsError(Errors);
            return;
        }

        await onIsValue(Value);
    }
}