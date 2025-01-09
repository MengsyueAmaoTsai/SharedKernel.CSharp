using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class EnumerationTests
{
    private sealed class TestEnumeration : Enumeration<TestEnumeration>
    {
        public static readonly TestEnumeration First = new(nameof(First), 1);
        public static readonly TestEnumeration Second = new(nameof(Second), 2);

        private TestEnumeration(string name, int value)
            : base(name, value)
        {
        }
    }

    [Fact]
    public void FromName_When_NameIsNotMatched_Should_ReturnMaybeWithNoValue()
    {
        // Arrange
        var name = "Third";

        // Act
        var enumeration = TestEnumeration.FromName(name);

        // Assert
        enumeration.HasValue.Should().BeFalse();
    }

    [Fact]
    public void FromName_When_NameIsMatched_Should_ReturnMaybeWithEnumeration()
    {
        // Arrange
        var name = "First";

        // Act
        var enumeration = TestEnumeration.FromName(name);

        // Assert
        enumeration.HasValue.Should().BeTrue();
        enumeration.Value.Should().Be(TestEnumeration.First);
    }

    [Fact]
    public void FromValue_When_ValueIsNotMatched_Should_ReturnMaybeWithNoValue()
    {
        // Arrange
        var value = 3;

        // Act
        var enumeration = TestEnumeration.FromValue(value);

        // Assert
        enumeration.HasValue.Should().BeFalse();
    }

    [Fact]
    public void FromValue_When_ValueIsMatched_Should_ReturnMaybeWithEnumeration()
    {
        // Arrange
        var value = 1;

        // Act
        var enumeration = TestEnumeration.FromValue(value);

        // Assert
        enumeration.HasValue.Should().BeTrue();
        enumeration.Value.Should().Be(TestEnumeration.First);
    }
}
