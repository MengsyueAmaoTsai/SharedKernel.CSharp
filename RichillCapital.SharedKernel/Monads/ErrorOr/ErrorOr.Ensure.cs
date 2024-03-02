namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public static ErrorOr<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error)
    {
        if (!ensure(value))
        {
            return error.ToErrorOr<TValue>();
        }

        return value.ToErrorOr();
    }

    public ErrorOr<TValue> Ensure(
        Func<TValue, bool> ensure,
        Error error) =>
        HasError ?
            Errors.ToErrorOr<TValue>() :
            !ensure(Value) ?
                error.ToErrorOr<TValue>() :
                Value.ToErrorOr();
}