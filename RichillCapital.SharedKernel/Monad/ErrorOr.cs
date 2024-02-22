namespace RichillCapital.SharedKernel.Monad;

public sealed partial record class ErrorOr<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;

    private ErrorOr(bool isError, IEnumerable<Error> errors, TValue value) =>
        (IsError, _errors, _value) = (isError, isError ? errors.ToList() : null, value);

    public bool IsError { get; private init; }

    public bool IsValue => !IsError;

    public IReadOnlyList<Error> Errors =>
        IsError ?
        _errors! :
        [Error.Null];

    public TValue Value => IsError ?
        throw new InvalidOperationException("Cannot access value for an error result.") :
        _value!;

    public static ErrorOr<TValue> Is(TValue value) =>
        new(false, Enumerable.Empty<Error>(), value);

    public static implicit operator ErrorOr<TValue>(TValue value) =>
        Is(value);

    public static ErrorOr<TValue> From(IEnumerable<Error> errors) =>
        new(true, errors, default!);

    public static implicit operator ErrorOr<TValue>(List<Error> errors) =>
        From(errors);

    public static ErrorOr<TValue> From(Error error) =>
        new(true, [error], default!);

    public static implicit operator ErrorOr<TValue>(Error error) =>
        From(error);

    public ErrorOr<TDestination> Map<TDestination>(Func<TValue, TDestination> map) =>
        IsError ?
            ErrorOr<TDestination>.From(Errors) :
            ErrorOr<TDestination>.Is(map(Value));

    public ErrorOr<TResult> Then<TResult>(Func<TValue, ErrorOr<TResult>> errorOrFunc) =>
        IsError ?
            ErrorOr<TResult>.From(Errors) :
            errorOrFunc(Value);

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> errorOrTask) =>
        IsError ?
            ErrorOr<TResult>.From(Errors) :
            await errorOrTask(Value);
}

public partial record class ErrorOr
{
    public static ErrorOr<TValue> Is<TValue>(TValue value) =>
        ErrorOr<TValue>.Is(value);

    public static ErrorOr<TValue> From<TValue>(IEnumerable<Error> errors) =>
        ErrorOr<TValue>.From(errors);

    public static ErrorOr<TValue> From<TValue>(Error error) =>
        ErrorOr<TValue>.From(error);

    public static ErrorOr<TValue> Ensure<TValue>(
        TValue value,
        Func<TValue, bool> predicate,
        Error error) =>
        predicate(value) ?
            ErrorOr<TValue>.Is(value) :
            ErrorOr<TValue>.From(error);

    public static ErrorOr<TValue> Combine<TValue>(params ErrorOr<TValue>[] errorOrs) =>
        errorOrs.Any(errorOr => errorOr.IsError) ?
            ErrorOr<TValue>.From(errorOrs
                .SelectMany(errorOr => errorOr.Errors)
                .Where(error => error != Error.Null)
                .Distinct()
                .ToArray()) :
            ErrorOr<TValue>.Is(errorOrs.First().Value);
}