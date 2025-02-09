namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ValueObjectTests
{
    private sealed class TestValueObject : ValueObject
    {
        public TestValueObject(string stringValue, int intValue) =>
            (StringValue, IntValue) = (stringValue, intValue);

        public string StringValue { get; private init; }

        public int IntValue { get; private init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return StringValue;
            yield return IntValue;
        }
    }

    [Fact]
    public void Equals_When_ValueObjectsHaveTheSameValues_Should_ReturnTrue()
    {
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        var result = valueObject1.Equals(valueObject2);

        result.ShouldBeTrue();
    }

    [Fact]
    public void Equals_When_ValueObjectsHaveDifferentValues_Should_ReturnFalse()
    {
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        var result = valueObject1.Equals(valueObject2);

        result.ShouldBeFalse();
    }

    [Fact]
    public void EqualOperator_When_ValueObjectsHaveTheSameValues_Should_ReturnTrue()
    {
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        var result = valueObject1 == valueObject2;

        result.ShouldBeTrue();
    }

    [Fact]
    public void EqualOperator_When_ValueObjectsHaveDifferentValues_Should_ReturnFalse()
    {
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        var result = valueObject1 == valueObject2;

        result.ShouldBeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_ValueObjectsHaveTheSameValues_Should_ReturnFalse()
    {
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        var result = valueObject1 != valueObject2;

        result.ShouldBeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_ValueObjectsHaveDifferentValues_Should_ReturnTrue()
    {
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        var result = valueObject1 != valueObject2;

        result.ShouldBeTrue();
    }

    [Fact]
    public void GetHashCode_When_ValueObjectsHaveTheSameValues_Should_ReturnTheSameHashCode()
    {
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        hashCode1.ShouldBe(hashCode2);
    }

    [Fact]
    public void GetHashCode_When_ValueObjectsHaveDifferentValues_Should_ReturnDifferentHashCodes()
    {
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        hashCode1.ShouldNotBe(hashCode2);
    }
}
