namespace RichillCapital.SharedKernel.Diagnostics;

public static partial class ThrowableExtensions
{
    public static Throwable<TValue> Throw<TValue>(
        this TValue value) => new(value, string.Empty);
}