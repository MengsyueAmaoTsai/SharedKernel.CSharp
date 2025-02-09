using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

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

    public bool HasValue => _hasValue;
    public bool IsNull => !_hasValue;
    public TValue Value => HasValue ? _value :
        throw new InvalidOperationException(AccessValueOnNullMaybeMessage);

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

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Null() => new(false, default!);
}
