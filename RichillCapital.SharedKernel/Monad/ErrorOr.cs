namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct ErrorOr<TValue>
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

    public Error FirstError =>
        IsError ?
        _errors!.First() :
        Error.Null;

    public TValue Value => IsError ?
        throw new InvalidOperationException("Cannot access value for an error result.") :
        _value!;

    public TValue ValueOrDefault => IsError ? default! : _value!;

    public static implicit operator ErrorOr<TValue>(TValue value) =>
        ErrorOr<TValue>.Is(value);

    public static implicit operator ErrorOr<TValue>(List<Error> errors) =>
        ErrorOr<TValue>.From(errors);

    public static implicit operator ErrorOr<TValue>(Error[] errors) =>
        ErrorOr<TValue>.From(errors);

    public static implicit operator ErrorOr<TValue>(Error error) =>
        ErrorOr<TValue>.From(error);

}

public readonly partial record struct ErrorOr
{
}