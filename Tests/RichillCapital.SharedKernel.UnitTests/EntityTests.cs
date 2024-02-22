using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EntityTests
{
    [Fact]
    public void EqualsOperator_WithSameValues_ReturnsTrue()
    {
        // Arrange
        var id = GenerateId();
        var entity1 = new TestEntity(id, "test1");
        var entity2 = new TestEntity(id, "test2");

        // Act
        var areEqual = entity1 == entity2;

        // Assert
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_WithDifferentValues_ReturnsFalse()
    {
        // Arrange
        var entity1 = new TestEntity(GenerateId(), "test1");
        var entity2 = new TestEntity(GenerateId(), "test2");

        // Act
        var areEqual = entity1 == entity2;

        // Assert
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WithSameValues_ReturnsFalse()
    {
        // Arrange
        var id = GenerateId();
        var entity1 = new TestEntity(id, "test1");
        var entity2 = new TestEntity(id, "test2");

        // Act
        var areNotEqual = entity1 != entity2;

        // Assert
        areNotEqual.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WithDifferentValues_ReturnsTrue()
    {
        // Arrange
        var entity1 = new TestEntity(GenerateId(), "test");
        var entity2 = new TestEntity(GenerateId(), "test2");

        // Act
        var areNotEqual = entity1 != entity2;

        // Assert
        areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenComparingTwoEntitiesWithTheSameId()
    {
        // Arrange
        var id = GenerateId();
        var entity1 = new TestEntity(id, "test1");
        var entity2 = new TestEntity(id, "test2");

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparingTwoEntitiesWithDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity(GenerateId(), "test1");
        var entity2 = new TestEntity(GenerateId(), "test2");

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparingEntityToNull()
    {
        // Arrange
        var entity = new TestEntity(GenerateId(), "test");

        // Act
        var result = entity.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparingEntityToDifferentType()
    {
        // Arrange
        var entity = new TestEntity(GenerateId(), "test");

        // Act
        var result = entity.Equals(new object());

        // Assert
        result.Should().BeFalse();
    }

    private static TestEntityId GenerateId() => new(Guid.NewGuid().ToString());
}