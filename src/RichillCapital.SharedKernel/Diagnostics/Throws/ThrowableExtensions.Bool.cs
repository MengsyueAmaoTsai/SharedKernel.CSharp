using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Diagnostics;

public static partial class ThrowableExtensions
{
    public static ref readonly Throwable<TValue> IfTrue<TValue>(
        this in Throwable<TValue> throwable,
        Func<TValue, bool> predicate,
        [CallerArgumentExpression("predicate")] string? predicateName = null)
        where TValue : notnull
    {
        if (predicate(throwable.Value))
        {
            Thrower.Throw(throwable.ParamName, $"Value should not meet condition (condition: '{predicateName}').");
        }

        return ref throwable;
    }

    public static ref readonly Throwable<TValue> IfFalse<TValue>(
        this in Throwable<TValue> throwable,
        Func<TValue, bool> predicate,
        [CallerArgumentExpression("predicate")] string? predicateName = null)
        where TValue : notnull
    {
        if (!predicate(throwable.Value))
        {
            Thrower.Throw(throwable.ParamName, $"Value should meet condition (condition: '{predicateName}').");
        }

        return ref throwable;
    }
}