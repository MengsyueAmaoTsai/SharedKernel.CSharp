
namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public TResult Match<TResult>(
    Func<IEnumerable<Error>, TResult> onError,
    Func<TValue, TResult> onValue) =>
    IsError ?
        onError(_errors) :
        onValue(_value);

    public async Task<TResult> Match<TResult>(
        Func<IEnumerable<Error>, Task<TResult>> onError,
        Func<TValue, Task<TResult>> onValue) =>
        IsError ?
            await onError(_errors) :
            await onValue(_value);
}