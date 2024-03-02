using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    /// <summary>
    /// Ensures that a value satisfies a condition.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            error.ToResult<TValue>() :
            value.ToResult();
}

public readonly partial record struct Result
{
}

public static partial class ResultExtensions
{
    public static Result<TValue> Ensure<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> ensure,
        Error error) =>
        result.IsFailure ?
            result.Error.ToResult<TValue>() :
            Result<TValue>.Ensure(result.Value, ensure, error);

    public static async Task<Result<TValue>> Ensure<TValue>(
        this Result<TValue> result,
        Func<TValue, Task<bool>> ensureTask,
        Func<TValue, Error> errorFactory) =>
        result.IsFailure ?
            result.Error.ToResult<TValue>() :
            !await ensureTask(result.Value) ?
                errorFactory(result.Value).ToResult<TValue>() :
                result.Value.ToResult();
}