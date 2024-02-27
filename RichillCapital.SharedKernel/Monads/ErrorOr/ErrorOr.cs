namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    private static readonly Error IsNotError = Error
        .Unexpected($"ErrorOr<{typeof(TValue)}> is not error");

    private readonly TValue _value;
    private readonly List<Error> _errors;

    private ErrorOr(Error error)
        : this(true, [error], default!)
    {
    }

    private ErrorOr(List<Error> errors)
        : this(true, errors, default!)
    {
    }

    private ErrorOr(Error[] errors)
        : this(true, [.. errors], default!)
    {
    }

    private ErrorOr(TValue value)
        : this(false, [], value)
    {
    }

    private ErrorOr(bool isError, List<Error> errors, TValue value) =>
        (IsError, _errors, _value) = (isError, errors, value);

    public bool IsError { get; private init; }

    public bool IsValue => !IsError;

    public List<Error> Errors =>
        IsError ?
            _errors :
            [IsNotError];

    public List<Error> ErrorsOrEmpty =>
        IsError ?
            _errors :
            new();

    public TValue Value => IsError ?
        throw new InvalidOperationException($"ErrorOr<{typeof(TValue)}> is not value") :
        _value;

    public TValue ValueOrDefault => IsError ?
        default! :
        _value;
}