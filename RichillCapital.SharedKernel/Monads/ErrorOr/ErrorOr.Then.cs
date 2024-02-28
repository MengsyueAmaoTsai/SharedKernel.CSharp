namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Then<TResult>(Func<TValue, TResult> valueFactory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            valueFactory(Value).ToErrorOr();

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<TResult>> valueFactory) =>
        HasError ?
            Errors.ToErrorOr<TResult>() :
            await valueFactory(Value).ToErrorOr();
}