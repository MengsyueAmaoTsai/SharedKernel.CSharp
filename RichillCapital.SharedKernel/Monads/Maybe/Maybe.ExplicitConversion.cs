using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this TValue value) =>
        Maybe<TValue>.Have(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this ErrorOr<TValue> errorOr) =>
        errorOr.Match(_ => Maybe<TValue>.Null, Maybe<TValue>.Have);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> ToMaybe<TValue>(this Result<TValue> result) =>
        result.Match(Maybe<TValue>.Have, _ => Maybe<TValue>.Null);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this Task<TValue> valueTask) =>
        Maybe<TValue>.Have(await valueTask);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Maybe<TValue>> ToMaybe<TValue>(this ValueTask<TValue> valueTask) =>
        Maybe<TValue>.Have(await valueTask);
}