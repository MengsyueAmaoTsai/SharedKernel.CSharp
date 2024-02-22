
using RichillCapital.SharedKernel;

internal sealed class TestSingleValueObject : SingleValueObject<int>
{
    public TestSingleValueObject(int value)
        : base(value)
    {
    }
}