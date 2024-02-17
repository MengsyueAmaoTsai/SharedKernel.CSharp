
using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EntityTests
{
    private sealed class TestEntityId : SingleValueObject<string>
    {
        public TestEntityId(string value)
            : base(value)
        {
        }
    }

    private sealed class TestEntity : Entity<TestEntityId>
    {
        public TestEntity(TestEntityId id)
            : base(id)
        {
        }
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenComparingTwoEntitiesWithTheSameId()
    {
        // Arrange
        var id = GenerateId();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparingTwoEntitiesWithDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity(GenerateId());
        var entity2 = new TestEntity(GenerateId());

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparingEntityToNull()
    {
        // Arrange
        var entity = new TestEntity(GenerateId());

        // Act
        var result = entity.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparingEntityToDifferentType()
    {
        // Arrange
        var entity = new TestEntity(GenerateId());

        // Act
        var result = entity.Equals(new object());

        // Assert
        result.Should().BeFalse();
    }

    private static TestEntityId GenerateId() => new(Guid.NewGuid().ToString());
}