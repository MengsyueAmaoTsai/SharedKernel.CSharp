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
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this Task<TValue> valueTask) =>
        (await valueTask).ToMaybe();

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Maybe<TValue>> ToMaybe<TValue>(this ValueTask<TValue> valueTask) =>
        (await valueTask).ToMaybe();
}