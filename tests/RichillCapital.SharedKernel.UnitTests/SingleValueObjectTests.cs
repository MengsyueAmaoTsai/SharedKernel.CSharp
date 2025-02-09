namespace RichillCapital.SharedKernel.UnitTests;

public sealed class SingleValueObjectTests
{
    private sealed class TestSingleValueObject : SingleValueObject<string>
    {
        private TestSingleValueObject(string value)
            : base(value)
        {
        }

        public static TestSingleValueObject Create(string value) => new(value);
    }

    [Fact]
    public void ToString_When_ValueIsNotNull_Should_ReturnValue()
    {
        var value = "value";
        var singleValueObject = TestSingleValueObject.Create(value);

        singleValueObject.ToString().ShouldBe(value);
    }
}
