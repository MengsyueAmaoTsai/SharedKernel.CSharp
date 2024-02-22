namespace RichillCapital.SharedKernel.UnitTests.Common;

internal sealed class TestEntity : Entity<TestEntityId>
{
    public TestEntity(TestEntityId id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }
}

internal sealed class TestEntity2 : Entity<TestEntityId>
{
    public TestEntity2(TestEntityId id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }
}