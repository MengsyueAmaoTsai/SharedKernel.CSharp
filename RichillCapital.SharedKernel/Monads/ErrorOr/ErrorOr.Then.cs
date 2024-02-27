namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, ErrorOr<TResult>> onValue) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors.ToArray()) :
            onValue(Value);

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> onValueTask) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors.ToArray()) :
            await onValueTask(Value);

    public ErrorOr<TValue> Then(Action<TValue> onValue)
    {
        if (IsError)
        {
            return ErrorOr<TValue>.Is(_errors.ToArray());
        }

        onValue(Value);

        return _value.ToErrorOr();
    }

    public async Task<ErrorOr<TValue>> Then(Func<TValue, Task> onValueTask)
    {
        if (IsError)
        {
            return ErrorOr<TValue>.Is(_errors.ToArray());
        }

        await onValueTask(Value);

        return _value.ToErrorOr();
    }

    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> onValue) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors.ToArray()) :
            onValue(Value).ToErrorOr();

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<TResult>> onValueTask) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors.ToArray()) :
            await onValueTask(Value).ToErrorOr();
}