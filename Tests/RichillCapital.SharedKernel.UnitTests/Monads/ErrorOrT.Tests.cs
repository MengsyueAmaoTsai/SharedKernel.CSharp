// using FluentAssertions;

// using RichillCapital.SharedKernel.Monads;
// using RichillCapital.SharedKernel.UnitTests.Monads.Common;

// namespace RichillCapital.SharedKernel.UnitTests.Monads;

// public sealed partial class GenericErrorOrTests : MonadTests
// {
//     [Fact]
//     public void Errors_When_ErrorOrIsError_Should_ReturnErrors()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.From(ValidationErrors.ToList());

//         // Act
//         var errors = errorOrInt.Errors;

//         // Assert
//         errors.Should().HaveCount(ValidationErrors.Length)
//             .And.BeEquivalentTo(ValidationErrors);
//     }

//     [Fact]
//     public void Errors_When_ErrorOrIsValue_Should_ReturnEmptyList()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.Is(IntValue);

//         // Act
//         var errors = errorOrInt.Errors;

//         // Assert
//         errors.Should().HaveCount(1);
//         errors.First().Type.Should().Be(ErrorType.Unexpected);
//         errors.First().Message.Should().Be($"ErrorOr<{typeof(int)}> is not error");
//     }

//     [Fact]
//     public void Value_When_ErrorOrIsError_Should_ThrowInvalidOperationException()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.From(NotFoundError);

//         // Act
//         Action act = () => _ = errorOrInt.Value;

//         // Assert
//         act.Should().Throw<InvalidOperationException>()
//             .WithMessage($"ErrorOr<{typeof(int)}> is not value");
//     }

//     [Fact]
//     public void Value_When_ErrorOrIsValue_Should_ReturnValue()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.Is(IntValue);

//         // Act
//         var value = errorOrInt.Value;

//         // Assert
//         value.Should().Be(IntValue);
//     }


//     [Fact]
//     public void ValueOrDefault_When_ErrorOrIsError_Should_ReturnDefault()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.From(NotFoundError);

//         // Act
//         var valueOrDefault = errorOrInt.ValueOrDefault;

//         // Assert
//         valueOrDefault.Should().Be(default);
//     }

//     [Fact]
//     public void ValueOrDefault_When_ErrorOrIsValue_Should_ReturnValue()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.Is(IntValue);

//         // Act
//         var valueOrDefault = errorOrInt.ValueOrDefault;

//         // Assert
//         valueOrDefault.Should().Be(IntValue);
//     }

//     [Fact]
//     public void ErrorsOrEmpty_When_ErrorOrIsError_Should_ReturnErrors()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.From(ValidationErrors.ToList());

//         // Act
//         var errors = errorOrInt.ErrorsOrEmpty;

//         // Assert
//         errors.Should().HaveCount(ValidationErrors.Length)
//             .And.BeEquivalentTo(ValidationErrors);
//     }

//     [Fact]
//     public void ErrorsOrEmpty_When_ErrorOrIsValue_Should_ReturnEmptyList()
//     {
//         // Arrange
//         var errorOrInt = ErrorOr<int>.Is(IntValue);

//         // Act
//         var errors = errorOrInt.ErrorsOrEmpty;

//         // Assert
//         errors.Should().BeEmpty();
//     }
// }