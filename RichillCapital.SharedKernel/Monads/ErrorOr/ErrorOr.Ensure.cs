namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public ErrorOr<TValue> Ensure(
        Func<TValue, bool> ensure,
        Error error) =>
        HasError ?
            Errors.ToErrorOr<TValue>() :
            !ensure(Value) ?
                error.ToErrorOr<TValue>() :
                Value.ToErrorOr();
}