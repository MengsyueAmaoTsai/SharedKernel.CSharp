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

    [Fact]
    public void Members_When_EnumerationHasMembers_Should_ReturnReadOnlyCollection()
    {
        // Act
        var members = TestEnumeration.Members;

        // Assert
        members.Should().BeEquivalentTo(new[] { TestEnumeration.First, TestEnumeration.Second });
    }

    [Fact]
    public void Name_When_EnumerationIsCreated_Should_ReturnName()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration.Name;

        // Assert
        result.Should().Be(name);
    }

    [Fact]
    public void Value_When_EnumerationIsCreated_Should_ReturnValue()
    {
        // Arrange
        var value = 1;
        var enumeration = TestEnumeration.FromValue(value).Value;

        // Act
        var result = enumeration.Value;

        // Assert
        result.Should().Be(value);
    }

    [Fact]
    public void ToString_When_EnumerationIsCreated_Should_ReturnName()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration.ToString();

        // Assert
        result.Should().Be(name);
    }

    [Fact]
    public void GetHashCode_When_EnumerationIsCreated_Should_ReturnNameAndValueHashCode()
    {
        // Arrange
        var value = 1;
        var enumeration = TestEnumeration.FromValue(value).Value;

        // Act
        var hashCode = enumeration.GetHashCode();

        // Assert
        hashCode.Should().Be(HashCode.Combine(enumeration.Name, enumeration.Value));
    }

    [Fact]
    public void Equals_When_EnumerationIsComparedToItself_Should_ReturnTrue()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration.Equals(enumeration);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_EnumerationIsComparedToNull_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_EnumerationIsComparedToOtherType_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration.Equals(new object());

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_EnumerationIsComparedToEnumerationWithDifferentName_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration1 = TestEnumeration.FromName(name).Value;
        var enumeration2 = TestEnumeration.FromName("Second").Value;

        // Act
        var result = enumeration1.Equals(enumeration2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_EnumerationIsComparedToEnumerationWithDifferentValue_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration1 = TestEnumeration.FromName(name).Value;
        var enumeration2 = TestEnumeration.FromValue(2).Value;

        // Act
        var result = enumeration1.Equals(enumeration2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equal_Operator_When_EnumerationIsComparedToItself_Should_ReturnTrue()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration == TestEnumeration.First;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void NotEqual_Operator_When_EnumerationIsComparedToItself_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration != TestEnumeration.First;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equal_Operator_When_EnumerationIsComparedToNull_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration == null;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqual_Operator_When_EnumerationIsComparedToNull_Should_ReturnTrue()
    {
        // Arrange
        var name = "First";
        var enumeration = TestEnumeration.FromName(name).Value;

        // Act
        var result = enumeration != null;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equal_Operator_When_EnumerationIsComparedToEnumerationWithDifferentName_Should_ReturnFalse()
    {
        // Arrange
        var name = "First";
        var enumeration1 = TestEnumeration.FromName(name).Value;
        var enumeration2 = TestEnumeration.FromName("Second").Value;

        // Act
        var result = enumeration1 == enumeration2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqual_Operator_When_EnumerationIsComparedToEnumerationWithDifferentName_Should_ReturnTrue()
    {
        // Arrange
        var name = "First";
        var enumeration1 = TestEnumeration.FromName(name).Value;
        var enumeration2 = TestEnumeration.FromName("Second").Value;

        // Act
        var result = enumeration1 != enumeration2;

        // Assert
        result.Should().BeTrue();
    }
}