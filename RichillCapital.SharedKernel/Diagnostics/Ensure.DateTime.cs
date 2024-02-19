using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Diagnostic;

public static partial class Ensure
{
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
}