namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Ensure(
    Func<TValue, bool> ensure,
    Error error) =>
    IsError ?
        ErrorOr<TValue>.Is(_errors) :
        ensure(_value) ?
            ErrorOr<TValue>.Is(_value) :
            ErrorOr<TValue>.Is(error);

    public ErrorOr<TValue> Ensure(
        (Func<TValue, bool> predicate, Error error) ensure) =>
        Ensure(ensure.predicate, ensure.error);
}