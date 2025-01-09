using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    /// <summary>
    /// Converts a value to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> With(TValue value) => new(value);

    /// <summary>
    /// Converts a <see cref="Task{TValue}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> WithError(Error error) => new(error);

    /// <summary>
    /// Converts a <see cref="List{Error}"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> WithError(List<Error> errors) => new(errors);

    /// <summary>
    /// Converts an <see cref="Error[]"/> to an <see cref="ErrorOr{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> WithError(Error[] errors) => new(errors);
}