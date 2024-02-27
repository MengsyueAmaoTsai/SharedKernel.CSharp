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
            return;
        }

        onSuccess(Value);
    }

    public async Task Switch(
        Func<TValue, Task> onSuccess,
        Func<Error, Task> onFailure)
    {
        if (IsFailure)
        {
            await onFailure(Error);
            return;
        }

        await onSuccess(Value);
    }
}

public readonly partial record struct Result
{
}