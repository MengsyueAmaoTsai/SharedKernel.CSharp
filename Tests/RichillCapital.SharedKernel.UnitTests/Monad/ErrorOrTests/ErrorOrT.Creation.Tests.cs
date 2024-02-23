using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Is_When_ValueIsProvided_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Is(IntValue);
        ErrorOr<string> errorOrString = ErrorOr<string>.Is(StringValue);
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.Is(BoolValue);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.Is(ByteValue);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr<TestEntity>.Is(TestEntity);

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
        ErrorOr<int> errorOrInt = ErrorOr<int>.From(errors);
        ErrorOr<string> errorOrString = ErrorOr<string>.From(errors);
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.From(errors);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.From(errors);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.From(errors);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr<TestEntity>.From(errors);

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
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.From(TestError);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.From(TestError);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.From(TestError);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr<TestEntity>.From(TestError);

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
        // Arrange
        Func<int, bool> intPredicate = value => value > 0;
        Func<string, bool> stringPredicate = value => value.Length > 0;
        Func<bool, bool> boolPredicate = value => value;
        Func<byte, bool> bytePredicate = value => value > 0;
        Func<DateTimeOffset, bool> dateTimePredicate = value => value > DateTimeOffset.MinValue;
        Func<TestEntity, bool> entityPredicate = value => value != null;

        // Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Ensure(IntValue, intPredicate, TestError);
        ErrorOr<string> errorOrString = ErrorOr<string>.Ensure(StringValue, stringPredicate, TestError);
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.Ensure(BoolValue, boolPredicate, TestError);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.Ensure(ByteValue, bytePredicate, TestError);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.Ensure(DateTimeValue, dateTimePredicate, TestError);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr<TestEntity>.Ensure(TestEntity, entityPredicate, TestError);

        // Assert
        errorOrInt.ShouldBeValue(IntValue);
        errorOrString.ShouldBeValue(StringValue);
        errorOrBool.ShouldBeValue(BoolValue);
        errorOrByte.ShouldBeValue(ByteValue);
        errorOrDateTime.ShouldBeValue(DateTimeValue);
        errorOrEntity.ShouldBeValue(TestEntity);
    }

    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnErrorOrWithErrors()
    {
        // Arrange
        Func<int, bool> intPredicate = value => value < 0;
        Func<string, bool> stringPredicate = value => value.Length == 0;
        Func<bool, bool> boolPredicate = value => !value;
        Func<byte, bool> bytePredicate = value => value < 0;
        Func<DateTimeOffset, bool> dateTimePredicate = value => value == DateTimeOffset.MinValue;
        Func<TestEntity, bool> entityPredicate = value => value == null;

        // Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Ensure(IntValue, intPredicate, TestError);
        ErrorOr<string> errorOrString = ErrorOr<string>.Ensure(StringValue, stringPredicate, TestError);
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.Ensure(BoolValue, boolPredicate, TestError);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.Ensure(ByteValue, bytePredicate, TestError);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.Ensure(DateTimeValue, dateTimePredicate, TestError);
        ErrorOr<TestEntity> errorOrEntity = ErrorOr<TestEntity>.Ensure(TestEntity, entityPredicate, TestError);

        // Assert
        errorOrInt.ShouldBeErrors([TestError]);
        errorOrString.ShouldBeErrors([TestError]);
        errorOrBool.ShouldBeErrors([TestError]);
        errorOrByte.ShouldBeErrors([TestError]);
        errorOrDateTime.ShouldBeErrors([TestError]);
        errorOrEntity.ShouldBeErrors([TestError]);
    }
}