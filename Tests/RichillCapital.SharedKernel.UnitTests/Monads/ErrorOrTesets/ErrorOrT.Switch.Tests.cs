using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Switch_When_ErrorOrIsValue_Should_InvokeActionWithValue() =>
        IntValue
            .ToErrorOr()
            .Switch(
                _ => throw new InvalidOperationException(),
                value => value.Should().Be(IntValue));

    [Fact]
    public void Switch_When_ErrorOrIsError_Should_InvokeActionWithErrors() =>
        NotFoundError
            .ToErrorOr<int>()
            .Switch(
                errors => errors.Should().BeEquivalentTo([NotFoundError]),
                _ => throw new InvalidOperationException());

    [Fact]
    public async void SwitchAsync_When_ErrorOrIsValue_Should_InvokeActionTaskWithValue() =>
        await IntValue
            .ToErrorOr()
            .Switch(
                _ => throw new InvalidOperationException(),
                value => Task
                    .FromResult(value)
                    .ContinueWith(task => task.Result.Should().Be(IntValue)));

    [Fact]
    public async void SwitchAsync_When_ErrorOrIsError_Should_InvokeActionTaskWithErrors() =>
        await NotFoundError
            .ToErrorOr<int>()
            .Switch(
                errors => Task
                    .FromResult(errors)
                    .ContinueWith(task => task.Result.Should().BeEquivalentTo([NotFoundError])),
                _ => throw new InvalidOperationException());
}