namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct ErrorOr<TValue>
{
    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> func) =>
        IsError ?
            ErrorOr<TResult>.From(Errors) :
            await func(Value);

    public ErrorOr<TResult> Then<TResult>(
        Func<TResult> func) =>
        IsError ?
            ErrorOr<TResult>.From(Errors) :
            ErrorOr<TResult>.Is(func());
}

public readonly partial record struct ErrorOr
{
}