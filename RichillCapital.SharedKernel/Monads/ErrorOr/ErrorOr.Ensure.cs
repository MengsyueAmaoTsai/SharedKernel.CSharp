using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    /// <summary>
    /// Ensures that a value satisfies a condition.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            error.ToErrorOr<TValue>() :
            value.ToErrorOr();
}

public static partial class ErrorOrExtensions
{
    public static ErrorOr<TValue> Ensure<TValue>(
        this ErrorOr<TValue> errorOr,
        Func<TValue, bool> ensure,
        Error error) =>
        errorOr.HasError ?
            errorOr.Errors.ToErrorOr<TValue>() :
            ErrorOr<TValue>.Ensure(errorOr.Value, ensure, error);
}