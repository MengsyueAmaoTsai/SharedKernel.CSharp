namespace RichillCapital.SharedKernel.UnitTests.Common;

public sealed class TestEntityId : SingleValueObject<int>
{
    public TestEntityId(int value)
        : base(value)
    {
    }
}

public sealed class TestEntityId2 : SingleValueObject<string>
{
    public TestEntityId2(string value)
        : base(value)
    {
    }
}