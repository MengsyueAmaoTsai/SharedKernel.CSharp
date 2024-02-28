namespace RichillCapital.SharedKernel.Diagnostics;

public readonly partial record struct Throwable<TValue>(TValue Value, string ParamName)
{
}