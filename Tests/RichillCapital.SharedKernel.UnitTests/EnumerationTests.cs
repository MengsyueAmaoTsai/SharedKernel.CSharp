using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EnumerationTests
{
    private sealed class TestEnumeration :
        Enumeration<TestEnumeration>
    {
        public static readonly TestEnumeration One = new(nameof(One), 1);
        public static readonly TestEnumeration Two = new(nameof(Two), 1);

        private TestEnumeration(string name, int value)
            : base(name, value)
        {
        }
    }

    [Fact]
    public void GetHashCode_ShouldReturnTheSameHashCodeAsTheValue()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act
        var hashCode1 = enumeration.GetHashCode();
        var hashCode2 = TestEnumeration.One.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void ToString_ShouldReturnTheNameOfTheEnumeration()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act
        var result = enumeration.ToString();

        // Assert
        result.Should().Be(enumeration.Name);
    }

    [Fact]
    public void FromValue_ShouldReturnEnumeration_WhenValueExists()
    {
        // Arrange
        var value = 1;

        // Act
        var result = TestEnumeration.FromValue(value);

        // Assert
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be(TestEnumeration.One);
    }

    [Fact]
    public void FromValue_ShouldReturnNull_WhenValueDoesNotExist()
    {
        // Arrange
        var value = 3;

        // Act
        var result = TestEnumeration.FromValue(value);

        // Assert
        result.HasValue.Should().BeFalse();
    }

    [Fact]
    public void FromName_ShouldReturnEnumeration_WhenNameExists()
    {
        // Arrange
        var name = "One";

        // Act
        var result = TestEnumeration.FromName(name);

        // Assert
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be(TestEnumeration.One);
    }

    [Fact]
    public void FromName_ShouldReturnNull_WhenNameDoesNotExist()
    {
        // Arrange
        var name = "Three";

        // Act
        var result = TestEnumeration.FromName(name);

        // Assert
        result.HasValue.Should().BeFalse();
    }

    [Fact]
    public void FromName_ShouldReturnEnumeration_WhenNameExistsAndIgnoreCaseIsTrue()
    {
        // Arrange
        var name = "one";

        // Act
        var result = TestEnumeration.FromName(name, true);

        // Assert
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be(TestEnumeration.One);
    }

    [Fact]
    public void FromName_ShouldReturnNull_WhenNameDoesNotExistAndIgnoreCaseIsTrue()
    {
        // Arrange
        var name = "three";

        // Act
        var result = TestEnumeration.FromName(name, true);

        // Assert
        result.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Members_ShouldReturnAllMembers()
    {
        // Arrange
        var expected = new[] { TestEnumeration.One, TestEnumeration.Two };

        // Act
        var result = TestEnumeration.Members;

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}