using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class ResultExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this TValue value) =>
        Result<TValue>.Success(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(this Task<TValue> valueTask) =>
        Result<TValue>.Success(await valueTask);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TValue>> ToResult<TValue>(this ValueTask<TValue> valueTask) =>
        Result<TValue>.Success(await valueTask);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this Error error) =>
        Result<TValue>.Failure(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this Maybe<TValue> maybe, Error error) =>
        maybe.Match(Result<TValue>.Success, () => Result<TValue>.Failure(error));

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> ToResult<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.Match(errors => Result<TValue>.Failure(errors.First()), Result<TValue>.Success);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result ToResult(this Error error) => Result.Failure(error);
}
