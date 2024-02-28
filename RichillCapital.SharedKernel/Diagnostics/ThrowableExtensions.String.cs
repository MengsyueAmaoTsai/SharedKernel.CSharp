namespace RichillCapital.SharedKernel.Diagnostics;

public static partial class ThrowableExtensions
{
    public static Throwable<string> IfEmpty(this Throwable<string> throwable)
    {
        return throwable;
    }

    public static ref readonly Throwable<string> IfWhiteSpace(
        this in Throwable<string> throwable)
    {
        if (throwable.Value.All(char.IsWhiteSpace))
        {
            Thrower.Throw(throwable.ParamName, "String should not be white space only.");
        }

        return ref throwable;
    }
}