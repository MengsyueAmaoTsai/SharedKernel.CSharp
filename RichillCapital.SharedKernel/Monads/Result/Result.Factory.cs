using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    /// <summary>
    /// Creates a new <see cref="Result{TValue}"/> with a value.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> With(TValue value) => new(value);

    /// <summary>
    /// Creates a new <see cref="Result{TValue}"/> with an error.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Failure(Error error) => new(error);
}

public readonly partial record struct Result
{
    /// <summary>
    /// Creates a new <see cref="Result"/> with an error.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Failure(Error error) => new(error);
}