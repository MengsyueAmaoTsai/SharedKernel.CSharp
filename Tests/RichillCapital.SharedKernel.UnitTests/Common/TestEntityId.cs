namespace RichillCapital.SharedKernel.UnitTests.Common;

internal sealed class TestEntityId : SingleValueObject<int>
{
    public TestEntityId(int value)
        : base(value)
    {
    }
}

internal sealed class TestEntityId2 : SingleValueObject<string>
{
    public TestEntityId2(string value)
        : base(value)
    {
    }
}