using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Null_Should_ReturnMaybeWithNoValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.Null;

        // Assert
        intMaybe.ShouldHasNoValue();
        stringMaybe.ShouldHasNoValue();
        boolMaybe.ShouldHasNoValue();
        byteMaybe.ShouldHasNoValue();
        dateTimeMaybe.ShouldHasNoValue();
        testEntityMaybe.ShouldHasNoValue();
    }
}