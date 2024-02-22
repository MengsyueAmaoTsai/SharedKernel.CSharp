namespace RichillCapital.SharedKernel.UnitTests.Common;

public sealed class TestEntity : Entity<TestEntityId>
{
    public TestEntity(TestEntityId id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }
}

public sealed class TestEntity2 : Entity<TestEntityId2>
{
    public TestEntity2(TestEntityId2 id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }
}