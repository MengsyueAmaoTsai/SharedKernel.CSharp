using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this TValue value) => ErrorOr<TValue>.Is(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this Task<TValue> valueTask) =>
        (await valueTask).ToErrorOr();

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ErrorOr<TValue>> ToErrorOr<TValue>(this ValueTask<TValue> valueTask) =>
        (await valueTask).ToErrorOr();

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error error) => ErrorOr<TValue>.Is(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this List<Error> errors) => ErrorOr<TValue>.Is(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error[] errors) => ErrorOr<TValue>.Is(errors);
}