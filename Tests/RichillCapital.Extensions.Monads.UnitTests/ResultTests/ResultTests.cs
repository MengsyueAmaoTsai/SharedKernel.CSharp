using RichillCapital.SharedKernel;

namespace RichillCapital.Extensions.Monads.UnitTests;

public abstract class ResultTests
{
    protected readonly static int Value = 5;

    protected readonly static Error UnexpectedError = Error.Unexpected("Unexpected error");
}