using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Diagnostic;

public static partial class Ensure
{
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