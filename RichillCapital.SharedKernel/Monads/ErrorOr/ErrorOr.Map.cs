namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TResult> Map<TResult>(Func<TValue, TResult> map) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors) :
            ErrorOr<TResult>.Is(map(_value));
}