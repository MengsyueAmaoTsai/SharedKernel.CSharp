using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EntityTests
{
    private sealed class TestEntityId : SingleValueObject<string>
    {
        private TestEntityId(string value)
            : base(value)
        {
        }

        public static TestEntityId Create(string id) => new(id);
    }

    private sealed class TestEntity : Entity<TestEntityId>
    {
        private TestEntity(TestEntityId id)
            : base(id)
        {
        }

        public static TestEntity Create(TestEntityId id) => new(id);
    }

    [Fact]
    public void Equals_When_EntitiesHaveTheSameId_Should_ReturnTrue()
    {
        // Arrange
        var id = TestEntityId.Create("id");
        var entity1 = TestEntity.Create(id);
        var entity2 = TestEntity.Create(id);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_EntitiesHaveDifferentIds_Should_ReturnFalse()
    {
        // Arrange
        var id1 = TestEntityId.Create("id1");
        var id2 = TestEntityId.Create("id2");
        var entity1 = TestEntity.Create(id1);
        var entity2 = TestEntity.Create(id2);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualOperator_When_EntitiesHaveTheSameId_Should_ReturnTrue()
    {
        // Arrange
        var id = TestEntityId.Create("id");
        var entity1 = TestEntity.Create(id);
        var entity2 = TestEntity.Create(id);

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualOperator_When_EntitiesHaveDifferentIds_Should_ReturnFalse()
    {
        // Arrange
        var id1 = TestEntityId.Create("id1");
        var id2 = TestEntityId.Create("id2");
        var entity1 = TestEntity.Create(id1);
        var entity2 = TestEntity.Create(id2);

        // Act
        var result = entity1 == entity2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_EntitiesHaveTheSameId_Should_ReturnFalse()
    {
        // Arrange
        var id = TestEntityId.Create("id");
        var entity1 = TestEntity.Create(id);
        var entity2 = TestEntity.Create(id);

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_EntitiesHaveDifferentIds_Should_ReturnTrue()
    {
        // Arrange
        var id1 = TestEntityId.Create("id1");
        var id2 = TestEntityId.Create("id2");
        var entity1 = TestEntity.Create(id1);
        var entity2 = TestEntity.Create(id2);

        // Act
        var result = entity1 != entity2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GetHashCode_When_EntitiesHaveTheSameId_Should_ReturnTheSameHashCode()
    {
        // Arrange
        var id = TestEntityId.Create("id");
        var entity1 = TestEntity.Create(id);
        var entity2 = TestEntity.Create(id);

        // Act
        var hashCode1 = entity1.GetHashCode();
        var hashCode2 = entity2.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void GetHashCode_When_EntitiesHaveDifferentIds_Should_ReturnDifferentHashCodes()
    {
        // Arrange
        var id1 = TestEntityId.Create("id1");
        var id2 = TestEntityId.Create("id2");
        var entity1 = TestEntity.Create(id1);
        var entity2 = TestEntity.Create(id2);

        // Act
        var hashCode1 = entity1.GetHashCode();
        var hashCode2 = entity2.GetHashCode();

        // Assert
        hashCode1.Should().NotBe(hashCode2);
    }
}