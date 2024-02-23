using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Map_WhenIsError_ReturnsErrorOrWithErrors()
    {
        // Arrange
        var errorOr = ErrorOr<int>.From([TestError]);

        // Act
        var result = errorOr.Map(value => value.ToString());

        // Assert
        result.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void Map_WhenIsNotError_ReturnsErrorOrWithValue()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act
        var result = errorOr.Map(value => value.ToString());

        // Assert
        result.ShouldBeValue("1");
    }
}