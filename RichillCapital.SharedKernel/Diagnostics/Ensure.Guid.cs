using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Diagnostic;

public static partial class Ensure
{
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
}