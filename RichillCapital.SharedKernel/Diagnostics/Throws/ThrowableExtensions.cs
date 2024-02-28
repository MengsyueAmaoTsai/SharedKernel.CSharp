using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Diagnostics;

public static partial class ThrowableExtensions
{
    public static Throwable<TValue> Throw<TValue>(
        this TValue value,
        [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull => new(value, paramName!);
}