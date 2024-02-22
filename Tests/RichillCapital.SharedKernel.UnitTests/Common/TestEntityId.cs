namespace RichillCapital.SharedKernel.UnitTests.Common;

internal sealed class TestEntityId : SingleValueObject<string>
{
    public TestEntityId(string value)
        : base(value)
    {
    }
}