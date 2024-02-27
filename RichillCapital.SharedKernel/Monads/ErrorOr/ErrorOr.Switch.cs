namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public void Switch(
        Action<IEnumerable<Error>> onError,
        Action<TValue> onValue)
    {
        if (IsError)
        {
            onError(Errors);
            return;
        }

        onValue(Value);
    }

    public async Task Switch(
        Func<IEnumerable<Error>, Task> onError,
        Func<TValue, Task> onValue)
    {
        if (IsError)
        {
            await onError(Errors);
            return;
        }

        await onValue(Value);
    }
}