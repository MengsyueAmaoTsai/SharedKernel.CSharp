
namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> OrElse(TValue value) =>
        IsError ?
            ErrorOr<TValue>.Is(value) :
            ErrorOr<TValue>.Is(_value);
}