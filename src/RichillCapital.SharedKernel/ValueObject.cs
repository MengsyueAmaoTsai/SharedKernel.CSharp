namespace RichillCapital.SharedKernel;

/// <summary>
/// Base class for value objects.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Determines whether two value objects are equal.
    /// </summary>
    /// <param name="a">The first value object to compare.</param>
    /// <param name="b">The second value object to compare.</param>
    /// <returns>True if the value objects are equal, false otherwise.</returns>
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    /// <param name="a">The first value object to compare.</param>
    /// <param name="b">The second value object to compare.</param>
    /// <returns>True if the value objects are not equal, false otherwise.</returns>
    public static bool operator !=(ValueObject? a, ValueObject? b) =>
          !(a == b);

    /// <summary>
    /// Determines whether the current value object is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current value object.</param>
    /// <returns>True if the objects are equal, false otherwise.</returns>
    public override bool Equals(object? obj) =>
        obj is ValueObject valueObject && ValuesAreEqual(valueObject);

    /// <summary>
    /// Determines whether the current value object is equal to another value object.
    /// </summary>
    /// <param name="other">The value object to compare with the current value object.</param>
    /// <returns>True if the value objects are equal, false otherwise.</returns>
    public bool Equals(ValueObject? other) =>
        other is not null && ValuesAreEqual(other);

    /// <summary>
    /// Returns the hash code for the value object.
    /// </summary>
    /// <returns>The hash code for the value object.</returns>
    public override int GetHashCode() =>
        GetAtomicValues()
            .Aggregate(
                default(int),
                (hashCode, value) =>
                    HashCode.Combine(hashCode, value.GetHashCode()));

    /// <summary>
    /// Gets the atomic values of the value object.
    /// </summary>
    /// <returns>An enumerable of the atomic values of the value object.</returns>
    protected abstract IEnumerable<object> GetAtomicValues();

    private bool ValuesAreEqual(ValueObject valueObject) =>
        GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
}

/// <summary>
/// Represents a base class for single-value value objects.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public abstract class SingleValueObject<TValue> : ValueObject
    where TValue : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SingleValueObject{TValue}"/> class.
    /// </summary>
    /// <param name="value">The value of the single-value object.</param>
    protected SingleValueObject(TValue value) => Value = value;

    /// <summary>
    /// Gets the value of the single-value object.
    /// </summary>
    public TValue Value { get; private init; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Value.ToString()!;

    /// <summary>
    /// Gets the atomic values of the single-value object.
    /// </summary>
    /// <returns>An enumerable collection of the atomic values.</returns>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
