using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EnumerationTests
{
    [Fact]
    public void Equals_When_ComparingWithNull_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        TestEnumeration.One.Equals(null).Should().BeFalse();
        TestEnumeration.Two.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentType_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        TestEnumeration.One.Equals(new object()).Should().BeFalse();
        TestEnumeration.Two.Equals(TestEnumeration2.Two).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithSameMember_Should_ReturnsTrue()
    {
        // Arrange & Act & Assert
        TestEnumeration.One.Equals(TestEnumeration.One).Should().BeTrue();
        TestEnumeration.Two.Equals(TestEnumeration.Two).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentMember_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        TestEnumeration.One.Equals(TestEnumeration.Two).Should().BeFalse();
        TestEnumeration.Two.Equals(TestEnumeration.One).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_When_ComparingWithSameMember_Should_ReturnsTrue()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        (enumeration == TestEnumeration.One).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_When_ComparingWithDifferentMember_Should_ReturnsFalse()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        (enumeration == TestEnumeration.Two).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_When_ComparingWithSameMember_Should_ReturnsFalse()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        (enumeration != TestEnumeration.One).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_When_ComparingWithDifferentMember_Should_ReturnsTrue()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        (enumeration != TestEnumeration.Two).Should().BeTrue();
    }

    [Fact]
    public void GetHashCode_When_ComparingWithSameMember_Should_ReturnsTrue()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        enumeration.GetHashCode().Should().Be(TestEnumeration.One.GetHashCode());
    }

    [Fact]
    public void GetHashCode_When_ComparingWithDifferentMember_Should_ReturnsFalse()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        enumeration.GetHashCode().Should().NotBe(TestEnumeration.Two.GetHashCode());
    }

    [Fact]
    public void ToString_Should_ReturnTheNameOfTheEnumeration()
    {
        // Arrange
        var enumeration = TestEnumeration.One;

        // Act & Assert
        enumeration.ToString().Should().Be(enumeration.Name);
    }

    [Fact]
    public void Members_Should_ReturnAllMembers()
    {
        // Arrange
        var expectedMembers = new[] { TestEnumeration.One, TestEnumeration.Two };

        // Act & Assert
        TestEnumeration.Members
            .Should().BeEquivalentTo(expectedMembers);
    }

    [Fact]
    public void FromName_When_NameExists_Should_ReturnEnumeration()
    {
        // Arrange
        var name = "One";

        // Act & Assert
        TestEnumeration.FromName(name)
            .ShouldHasValue(TestEnumeration.One);
    }

    [Fact]
    public void FromName_When_NameDoesNotExists_Should_ReturnNull()
    {
        // Arrange
        var name = "Three";

        // Act & Assert
        TestEnumeration.FromName(name)
            .ShouldHasNoValue();
    }

    [Fact]
    public void FromName_When_NameExistsAndIgnoreCase_Should_ReturnEnumeration()
    {
        // Arrange
        var name = "one";

        // Act & Assert
        TestEnumeration.FromName(name, true)
            .ShouldHasValue(TestEnumeration.One);
    }

    [Fact]
    public void FromName_When_NameDoesNotExistsAndIgnoreCase_Should_ReturnNull()
    {
        // Arrange
        var name = "three";

        // Act & Assert
        TestEnumeration.FromName(name, true)
            .ShouldHasNoValue();
    }

    [Fact]
    public void FromValue_When_ValueExists_Should_ReturnEnumeration()
    {
        // Arrange
        var value = 1;

        // Act & Assert
        TestEnumeration.FromValue(value)
            .ShouldHasValue(TestEnumeration.One);
    }

    [Fact]
    public void FromValue_When_ValueDoesNotExists_Should_ReturnNull()
    {
        // Arrange
        var value = 3;

        // Act & Assert
        TestEnumeration.FromValue(value)
            .ShouldHasNoValue();
    }
}