using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Map_WhenIsError_ReturnsErrorOrWithErrors()
    {
        var errorOr = ErrorOr<int>.From([TestError]);

        var result = errorOr.Map(value => value.ToString());

        result.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void Map_WhenIsNotError_ReturnsErrorOrWithValue()
    {
        var errorOr = ErrorOr<int>.Is(1);

        var result = errorOr.Map(value => value.ToString());

        result.ShouldBeValue("1");
    }
}