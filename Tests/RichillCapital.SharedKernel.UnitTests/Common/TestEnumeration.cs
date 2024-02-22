namespace RichillCapital.SharedKernel.UnitTests.Common;

internal sealed class TestEnumeration :
    Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration One = new(nameof(One), 1);
    public static readonly TestEnumeration Two = new(nameof(Two), 1);

    private TestEnumeration(string name, int value)
        : base(name, value)
    {
    }
}

internal sealed class TestEnumeration2 :
    Enumeration<TestEnumeration2>
{
    public static readonly TestEnumeration2 One = new(nameof(One), 1);
    public static readonly TestEnumeration2 Two = new(nameof(Two), 1);

    private TestEnumeration2(string name, int value)
        : base(name, value)
    {
    }
}