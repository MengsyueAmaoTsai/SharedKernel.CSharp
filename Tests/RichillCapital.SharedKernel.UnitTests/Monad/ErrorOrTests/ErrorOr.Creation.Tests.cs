using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class ErrorOrTests : MonadTests
{
    [Fact]
    public void Is_When_ValueIsProvided_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr.Is(IntValue);
        ErrorOr<string> errorOrString = ErrorOr.Is(StringValue);
        ErrorOr<bool> errorOrBool = ErrorOr.Is(BoolValue);
        ErrorOr<byte> errorOrByte = ErrorOr.Is(ByteValue);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr.Is(DateTimeValue);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr.Is(TestEntity);

        // Assert
        errorOrInt.ShouldBeValue(IntValue);
        errorOrString.ShouldBeValue(StringValue);
        errorOrBool.ShouldBeValue(BoolValue);
        errorOrByte.ShouldBeValue(ByteValue);
        errorOrDateTime.ShouldBeValue(DateTimeValue);
        errorOrEntity.ShouldBeValue(TestEntity);
    }

    [Fact]
    public void From_When_ErrorsAreProvided_Should_ReturnErrorOrWithErrors()
    {
        // Arrange
        var errors = new List<Error> { TestError, TestError, TestError };

        // Act
        ErrorOr<int> errorOrInt = ErrorOr.From<int>(errors);
        ErrorOr<string> errorOrString = ErrorOr.From<string>(errors);
        ErrorOr<bool> errorOrBool = ErrorOr.From<bool>(errors);
        ErrorOr<byte> errorOrByte = ErrorOr.From<byte>(errors);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr.From<DateTimeOffset>(errors);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr.From<TestEntity>(errors);

        // Assert
        errorOrInt.ShouldBeErrors(errors);
        errorOrString.ShouldBeErrors(errors);
        errorOrBool.ShouldBeErrors(errors);
        errorOrByte.ShouldBeErrors(errors);
        errorOrDateTime.ShouldBeErrors(errors);
        errorOrEntity.ShouldBeErrors(errors);
    }

    [Fact]
    public void From_When_ErrorIsProvided_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr.From<int>(TestError);
        ErrorOr<string> errorOrString = ErrorOr.From<string>(TestError);
        ErrorOr<bool> errorOrBool = ErrorOr.From<bool>(TestError);
        ErrorOr<byte> errorOrByte = ErrorOr.From<byte>(TestError);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr.From<DateTimeOffset>(TestError);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr.From<TestEntity>(TestError);

        // Assert
        errorOrInt.ShouldBeErrors([TestError]);
        errorOrString.ShouldBeErrors([TestError]);
        errorOrBool.ShouldBeErrors([TestError]);
        errorOrByte.ShouldBeErrors([TestError]);
        errorOrDateTime.ShouldBeErrors([TestError]);
        errorOrEntity.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr.Ensure(IntValue, value => value > 0, TestError);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr.Ensure(
            TestEntity,
            entity => entity is not null,
            TestError);

        // Assert
        errorOrInt.ShouldBeValue(IntValue);
        errorOrEntity.ShouldBeValue(TestEntity);
    }

    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<TestEntity> errorOrEntity = ErrorOr.Ensure(
            TestEntity,
            entity => entity is null,
            TestError);

        // Assert
        errorOrEntity.ShouldBeErrors([TestError]);
    }
}