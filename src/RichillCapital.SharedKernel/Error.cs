namespace RichillCapital.SharedKernel;

public readonly record struct Error
{
    public static readonly Error None = new(ErrorType.None, string.Empty, string.Empty);

    private Error(ErrorType type, string code, string message) =>
        (Type, Code, Message) = (type, code, message);

    public ErrorType Type { get; private init; }
    public string Code { get; private init; }
    public string Message { get; private init; }

    public static Error Create(
        ErrorType type,
        string code,
        string message)
    {
        if (type == ErrorType.None)
        {
            throw new ArgumentException("Error type cannot be None.", nameof(type));
        }

        return new(type, code, message);
    }
}
