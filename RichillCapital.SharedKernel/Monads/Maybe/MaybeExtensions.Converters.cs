using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this TValue value) =>
        Maybe<TValue>.With(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this Task<TValue> valueTask)
    {
        var value = await valueTask;
        return Maybe<TValue>.With(value);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Maybe<TValue>> ToMaybe<TValue>(this ValueTask<TValue> valueTask)
    {
        var value = await valueTask;
        return Maybe<TValue>.With(value);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.HasError ?
            Maybe<TValue>.Null :
            Maybe<TValue>.With(errorOr.Value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this Result<TValue> result) =>
        result.IsFailure ?
            Maybe<TValue>.Null :
            Maybe<TValue>.With(result.Value);
}