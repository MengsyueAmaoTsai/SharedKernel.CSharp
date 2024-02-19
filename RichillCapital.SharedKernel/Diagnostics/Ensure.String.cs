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
}