namespace RichillCapital.SharedKernel.Monad;

public readonly partial record struct Maybe<TValue>
{
    private readonly TValue? _value;

    public static readonly Maybe<TValue> Null = new(false, default!);

    private Maybe(bool hasValue, TValue value) =>
        (HasValue, _value) = (hasValue, value);

    public bool HasValue { get; private init; }

    public bool HasNoValue => !HasValue;

    public TValue Value => HasNoValue ?
        throw new InvalidOperationException($"Maybe<{typeof(TValue)}> has no value.") :
        _value!;

    public TValue ValueOrDefault => HasNoValue ? default! : _value!;

    public static implicit operator Maybe<TValue>(TValue value) =>
        value is null ?
            Null :
            With(value);

    public static implicit operator TValue(Maybe<TValue> maybe) => maybe.Value;
}

public readonly partial record struct Maybe
{
}