namespace RichillCapital.SharedKernel.UnitTests.Common;

internal sealed class TestValueObject(
    string TestString,
    int TestInt) :
    ValueObject
{
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return TestString;
        yield return TestInt;
    }
}