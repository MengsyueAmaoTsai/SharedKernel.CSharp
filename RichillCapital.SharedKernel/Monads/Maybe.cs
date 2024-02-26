using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    public static readonly Maybe<TValue> Null = new(false, default!);

    private readonly TValue? _value;

    private Maybe(TValue value)
        : this(true, value)
    {
    }

    private Maybe(bool hasValue, TValue value) =>
        (HasValue, _value) = (hasValue, value);

    public bool HasValue { get; private init; }

    public bool HasNoValue => !HasValue;

    public TValue Value => HasNoValue ?
        throw new InvalidOperationException($"Maybe<{typeof(TValue)}> is not value") :
        _value!;

    public TValue ValueOrDefault => HasNoValue ? default! : _value!;

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Have(TValue value) =>
        value is null ?
            Null :
            new(value);

    public TResult Match<TResult>(
        Func<TValue, TResult> onValue,
        Func<TResult> onNoValue) =>
        HasNoValue ?
            onNoValue() :
            onValue(Value);

    public async Task<TResult> Match<TResult>(
        Func<TValue, Task<TResult>> onValue,
        Func<Task<TResult>> onNoValue) =>
        HasNoValue ?
            await onNoValue() :
            await onValue(Value);
}