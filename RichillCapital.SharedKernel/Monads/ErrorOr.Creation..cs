namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public static ErrorOr<TValue> From(Error[] errors) => new([.. errors]);

    public static ErrorOr<TValue> From(List<Error> errors) => new(errors);

    public static ErrorOr<TValue> From(Error error) => new(error);

    public static ErrorOr<TValue> Is(TValue value) => new(value);
}