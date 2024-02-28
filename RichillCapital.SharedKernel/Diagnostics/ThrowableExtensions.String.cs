namespace RichillCapital.SharedKernel.Diagnostics;

public static partial class ThrowableExtensions
{
    public static Throwable<string> IfEmpty(this Throwable<string> throwable)
    {
        return throwable;
    }

    public static Throwable<string> IfWhiteSpace(this Throwable<string> throwable)
    {
        return throwable;
    }
}