using RichillCapital.SharedKernel;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public abstract class MonadTests
{
    protected readonly static int Value = 5;

    protected readonly static Error UnexpectedError = Error.Unexpected("Unexpected error");
}