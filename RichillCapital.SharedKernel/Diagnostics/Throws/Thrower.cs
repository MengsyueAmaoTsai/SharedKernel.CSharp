namespace RichillCapital.SharedKernel.Diagnostics;

public static class Thrower
{
    public static void ThrowNull(
        string paramName,
        string generalMessage = "Value cannot be null.") =>
        throw new ArgumentNullException(paramName, generalMessage);

    public static void ThrowOutOfRange<TValue>(
        string paramName,
        TValue value,
        string generalMessage = "Specified argument was out of the range of valid values.") =>
        throw new ArgumentOutOfRangeException(paramName, value, generalMessage);

    public static void Throw(
        string paramName,
        string? generalMessage = null) =>
        throw new ArgumentException(
            paramName: paramName,
            message: generalMessage);
}