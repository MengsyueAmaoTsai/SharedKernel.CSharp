using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void ImplicitCast_When_ValueIsProvided_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = IntValue;
        ErrorOr<string> errorOrString = StringValue;
        ErrorOr<bool> errorOrBool = BoolValue;
        ErrorOr<byte> errorOrByte = ByteValue;
        ErrorOr<DateTimeOffset> errorOrDateTime = DateTimeValue;
        ErrorOr<TestEntity> errorOrEntity = TestEntity;

        // Assert
        errorOrInt.ShouldBeValue(IntValue);
        errorOrString.ShouldBeValue(StringValue);
        errorOrBool.ShouldBeValue(BoolValue);
        errorOrByte.ShouldBeValue(ByteValue);
        errorOrDateTime.ShouldBeValue(DateTimeValue);
        errorOrEntity.ShouldBeValue(TestEntity);
    }

    [Fact]
    public void ImplicitCast_When_ErrorIsProvided_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = TestError;
        ErrorOr<string> errorOrString = TestError;
        ErrorOr<bool> errorOrBool = TestError;
        ErrorOr<byte> errorOrByte = TestError;
        ErrorOr<DateTimeOffset> errorOrDateTime = TestError;
        ErrorOr<TestEntity> errorOrEntity = TestError;

        // Assert
        errorOrInt.ShouldBeErrors([TestError]);
        errorOrString.ShouldBeErrors([TestError]);
        errorOrBool.ShouldBeErrors([TestError]);
        errorOrByte.ShouldBeErrors([TestError]);
        errorOrDateTime.ShouldBeErrors([TestError]);
        errorOrEntity.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void ImplicitCast_When_ErrorsAreProvided_Should_ReturnErrorOrWithErrors()
    {
        // Arrange
        var errors = new List<Error> { TestError, TestError, TestError };

        // Act
        ErrorOr<int> errorOrInt = errors;
        ErrorOr<string> errorOrString = errors;
        ErrorOr<bool> errorOrBool = errors;
        ErrorOr<byte> errorOrByte = errors;
        ErrorOr<DateTimeOffset> errorOrDateTime = errors;
        ErrorOr<TestEntity> errorOrEntity = errors;

        // Assert
        errorOrInt.ShouldBeErrors(errors);
        errorOrString.ShouldBeErrors(errors);
        errorOrBool.ShouldBeErrors(errors);
        errorOrByte.ShouldBeErrors(errors);
        errorOrDateTime.ShouldBeErrors(errors);
        errorOrEntity.ShouldBeErrors(errors);
    }

    [Fact]
    public void ImplicitCast_When_GivenErrorsArray_Should_ConvertToErrorOrWithErrors()
    {
        // Arrange
        var errors = new[] { TestError, TestError, TestError };

        // Act
        ErrorOr<int> errorOrInt = errors;
        ErrorOr<string> errorOrString = errors;
        ErrorOr<bool> errorOrBool = errors;
        ErrorOr<byte> errorOrByte = errors;
        ErrorOr<DateTimeOffset> errorOrDateTime = errors;
        ErrorOr<TestEntity> errorOrEntity = errors;

        // Assert
        errorOrInt.ShouldBeErrors(errors);
        errorOrString.ShouldBeErrors(errors);
        errorOrBool.ShouldBeErrors(errors);
        errorOrByte.ShouldBeErrors(errors);
        errorOrDateTime.ShouldBeErrors(errors);
        errorOrEntity.ShouldBeErrors(errors);
    }
}