namespace RichillCapital.SharedKernel.UnitTests;

public sealed class EntityTests
{
    internal sealed class TestEntity : Entity<TestEntityId>
    {
        public TestEntity(TestEntityId id, string name)
            : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    internal sealed class TestEntityId : SingleValueObject<string>
    {
        public TestEntityId(string value) : base(value)
        {
        }
    }

    internal sealed record TestDomainEvent : IDomainEvent
    {
    }

    [Fact]
    public void RaiseDomainEvent_Should_AddDomainEvent()
    {
        var entity = new TestEntity(new TestEntityId("1"), "TestEntity");
        var domainEvent = new TestDomainEvent();

        entity.RaiseDomainEvent(domainEvent);

        var domainEvents = entity.GetDomainEvents();

        domainEvents.ShouldContain(domainEvent);
    }

    [Fact]
    public void ClearDomainEvents_Should_RemoveAllDomainEvents()
    {
        var entity = new TestEntity(new TestEntityId("1"), "TestEntity");
        var domainEvent = new TestDomainEvent();

        entity.RaiseDomainEvent(domainEvent);
        entity.ClearDomainEvents();

        var domainEvents = entity.GetDomainEvents();

        domainEvents.ShouldBeEmpty();
    }

    [Fact]
    public void Equals_When_WithSameId_Should_ReturnTrue()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("1"), "TestEntity2");

        entity1.Equals(entity2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_When_WithDifferentId_Should_ReturnFalse()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("2"), "TestEntity");

        entity1.Equals(entity2).ShouldBeFalse();
    }

    [Fact]
    public void EqualOperator_When_WithSameId_Should_ReturnTrue()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("1"), "TestEntity");

        (entity1 == entity2).ShouldBeTrue();
    }

    [Fact]
    public void EqualOperator_When_WithDifferentId_Should_ReturnFalse()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("2"), "TestEntity");

        (entity1 == entity2).ShouldBeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_WithDifferentId_Should_ReturnTrue()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("2"), "TestEntity");

        (entity1 != entity2).ShouldBeTrue();
    }

    [Fact]
    public void NotEqualOperator_When_WithSameId_Should_ReturnFalse()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("1"), "TestEntity");

        (entity1 != entity2).ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_When_WithSameId_Should_ReturnSameHashCode()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("1"), "TestEntity");

        entity1.GetHashCode().ShouldBe(entity2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_When_WithDifferentId_Should_ReturnDifferentHashCode()
    {
        var entity1 = new TestEntity(new TestEntityId("1"), "TestEntity");
        var entity2 = new TestEntity(new TestEntityId("2"), "TestEntity");

        entity1.GetHashCode().ShouldNotBe(entity2.GetHashCode());
    }
}
