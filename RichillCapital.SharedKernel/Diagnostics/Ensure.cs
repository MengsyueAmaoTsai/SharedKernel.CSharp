using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Diagnostic;

public static partial class Ensure
{
    public static void NotEmpty(
        string value,
        string message,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(message, parameterName);
        }
    }

    public static void NotEmpty(
        Guid value,
        string message,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(message, parameterName);
        }
    }

    public static void NotEmpty(
        DateTime value,
        string message,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value == default)
        {
            throw new ArgumentException(message, parameterName);
        }
    }

    public static void NotNull<TValue>(
        TValue? value,
        string message,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where TValue : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName, message);
        }
    }
}