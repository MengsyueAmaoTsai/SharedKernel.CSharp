namespace RichillCapital.SharedKernel.Diagnostics;

public static partial class Ensure
{
    public static void NotEmpty(string value) => value.Throw().IfEmpty();
}