namespace RichillCapital.SharedKernel.UnitTests.Monad.Common;

public abstract class MonadTests
{
    protected static readonly int IntValue = 10;
    protected static readonly string StringValue = "Hello, World!";
    protected static readonly bool BoolValue = true;
    protected static readonly byte ByteValue = 0x0F;
    protected static readonly DateTimeOffset DateTimeValue = DateTimeOffset.Now;
    protected static readonly TestObject TestObjectValue = new("Test Object");
    protected static readonly Error TestError = Error.Invalid("Test Error Message");

    protected static readonly IEnumerable<TestObject> TestObjects =
    [
        new TestObject("Test 1"),
        new TestObject("Test 2"),
    ];
}