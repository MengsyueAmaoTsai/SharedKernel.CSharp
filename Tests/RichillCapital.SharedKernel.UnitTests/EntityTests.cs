using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EntityTests
{
    private static readonly TestEntity Entity = new(new TestEntityId(1), "test");
    private static readonly TestEntity EntityWithSameId = new(new TestEntityId(1), "test");
    private static readonly TestEntity EntityWithDifferentId = new(new TestEntityId(2), "test");
    private static readonly TestEntity2 EntityWithDifferentType = new(new TestEntityId2("1"), "test");

    [Fact]
    public void Equals_When_ComparingWithNull_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        Entity.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentType_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        Entity.Equals(new object()).Should().BeFalse();
        Entity.Equals(EntityWithDifferentType).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithSameTypeAndSameId_Should_ReturnsTrue()
    {
        // Arrange & Act & Assert
        Entity.Equals(EntityWithSameId).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ComparingWithSameTypeAndDifferentId_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        Entity.Equals(EntityWithDifferentId).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_WithSameValues_ReturnsTrue()
    {
        // Arrange & Act & Assert
        (Entity == EntityWithSameId).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_WithDifferentValues_ReturnsFalse()
    {
        // Arrange & Act & Assert
        (Entity == EntityWithDifferentId).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WithSameValues_ReturnsFalse()
    {
        // Arrange & Act & Assert
        (Entity != EntityWithSameId).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WithDifferentValues_ReturnsTrue()
    {
        // Arrange & Act & Assert
        (Entity != EntityWithDifferentId).Should().BeTrue();
    }

    [Fact]
    public void GetHashCode_WithSameValues_ReturnsTrue()
    {
        // Arrange & Act & Assert
        Entity.GetHashCode().Should().Be(EntityWithSameId.GetHashCode());
    }

    [Fact]
    public void GetHashCode_WithDifferentValues_ReturnsFalse()
    {
        // Arrange & Act & Assert
        Entity.GetHashCode().Should().NotBe(EntityWithDifferentId.GetHashCode());
    }
}