using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

/// <summary>
/// Represents an optional value that may or may not be present.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public readonly partial record struct Maybe<TValue>
{
    internal const string AccessValueOnNullMaybeMessage = "Can not access value on a null Maybe";

    private readonly bool _hasValue;
    private readonly TValue _value;

    private Maybe(bool hasValue, TValue value)
    {
        _hasValue = hasValue;
        _value = value;
    }

    /// <summary>
    /// Gets a value indicating whether the Maybe has a value.
    /// </summary>
    public bool HasValue => _hasValue;

    /// <summary>
    /// Gets a value indicating whether the Maybe is null.
    /// </summary>
    public bool IsNull => !_hasValue;

    /// <summary>
    /// Gets the value of the Maybe. Throws an exception if the Maybe is null.
    /// </summary>
    public TValue Value => HasValue ? _value :
        throw new InvalidOperationException(AccessValueOnNullMaybeMessage);

    /// <summary>
    /// Creates a new Maybe with the specified value.
    /// </summary>
    /// <param name="value">The value to wrap in a Maybe.</param>
    /// <returns>A Maybe instance containing the specified value.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> With(TValue value)
    {
        if (value is null)
        {
            return Null();
        }

        return new Maybe<TValue>(true, value);
    }

    /// <summary>
    /// Creates a new null Maybe.
    /// </summary>
    /// <returns>A null Maybe instance.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Null() => new(false, default!);
}
