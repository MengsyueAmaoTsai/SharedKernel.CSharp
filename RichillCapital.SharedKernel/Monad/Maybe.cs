namespace RichillCapital.SharedKernel.Monad;

public readonly record struct Maybe<TValue>
{
    private readonly TValue? _value;

    public static readonly Maybe<TValue> Null = new(false, default!);

    private Maybe(bool hasValue, TValue value) =>
        (HasValue, _value) = (hasValue, value);

    public bool HasValue { get; private init; }

    public bool HasNoValue => !HasValue;

    public TValue Value => HasNoValue ?
        throw new InvalidOperationException("Maybe has no value.") :
        _value!;

    public static Maybe<TValue> With(TValue value) => new(true, value);

    public static implicit operator Maybe<TValue>(TValue value) =>
        value is null ?
            Null :
            With(value);

    public static implicit operator TValue(Maybe<TValue> maybe) => maybe.Value;

    public Maybe<TValue> OrElse(Maybe<TValue> other) =>
        HasValue ? this : other;

    public Maybe<TDestination> Map<TDestination>(Func<TValue, TDestination> map) =>
         HasValue ?
            Maybe<TDestination>.With(map(Value)) :
            Maybe<TDestination>.Null;
}

public readonly record struct Maybe
{
    public static Maybe<TValue> With<TValue>(TValue value) =>
        Maybe<TValue>.With(value);
}