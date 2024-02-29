namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            error.ToResult<TValue>() :
            value.ToResult();

    public static Result<TValue> Ensure(
        TValue value,
        params (Func<TValue, bool> ensure, Error error)[] rules)
    {
        var results = rules
            .Select(rule => Ensure(value, rule.ensure, rule.error))
            .ToArray();

        return results.Any(result => result.IsFailure) ?
            results.First(result => result.IsFailure).Error.ToResult<TValue>() :
            value.ToResult();
    }
}