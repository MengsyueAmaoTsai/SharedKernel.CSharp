namespace RichillCapital.SharedKernel.UnitTests.Common;

internal sealed class TestEntity : Entity<TestEntityId>
{
    public TestEntity(TestEntityId id)
        : base(id)
    {
    }
}
