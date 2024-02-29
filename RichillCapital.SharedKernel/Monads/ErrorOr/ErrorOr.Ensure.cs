namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public static ErrorOr<TValue> Ensure(TValue value, Func<TValue, bool> ensure, Error error)
    {
        if (!ensure(value))
        {
            return error.ToErrorOr<TValue>();
        }

        return value.ToErrorOr();
    }

    public static ErrorOr<TValue> Ensure(
        TValue value,
        params (Func<TValue, bool> ensure, Error error)[] rules) =>
        ErrorOr<TValue>
            .Combine(rules
                .Select(rule => Ensure(value, rule.ensure, rule.error))
                .ToArray());
}