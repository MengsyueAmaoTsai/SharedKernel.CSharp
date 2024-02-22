
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Map_When_ResultIsSuccess_Should_ReturnMappedResult()
    {
        // Arrange
        var intResult = Result<int>.Success(IntValue);
        var stringValueResult = Result<string>.Success(StringValue);
        var boolResult = Result<bool>.Success(BoolValue);
        var byteResult = Result<byte>.Success(ByteValue);
        var dateTimeResult = Result<DateTimeOffset>.Success(DateTimeValue);
        var testEntityResult = Result<TestEntity>.Success(TestEntity);

        // Act
        var intMappedResult = intResult.Map(i => i.ToString());
        var stringMappedResult = stringValueResult.Map(s => s.ToUpper());
        var boolMappedResult = boolResult.Map(b => !b);
        var byteMappedResult = byteResult.Map(b => b * 2);
        var dateTimeMappedResult = dateTimeResult.Map(d => d.AddDays(1));
        var testEntityMappedResult = testEntityResult.Map(e => new TestEntity(e.Id, e.Name));

        // Assert
        intMappedResult.ShouldBeSuccessResultWithValue(IntValue.ToString());
        stringMappedResult.ShouldBeSuccessResultWithValue(StringValue.ToUpper());
        boolMappedResult.ShouldBeSuccessResultWithValue(!BoolValue);
        byteMappedResult.ShouldBeSuccessResultWithValue((byte)(ByteValue * 2));
        dateTimeMappedResult.ShouldBeSuccessResultWithValue(DateTimeValue.AddDays(1));
        testEntityMappedResult.ShouldBeSuccessResultWithValue(new TestEntity(TestEntity.Id, TestEntity.Name));
    }

    [Fact]
    public void Map_When_ResultIsFailure_Should_ReturnFailureResult()
    {
        // Arrange
        var intResult = Result<int>.Failure(TestError);
        var stringValueResult = Result<string>.Failure(TestError);
        var boolResult = Result<bool>.Failure(TestError);
        var byteResult = Result<byte>.Failure(TestError);
        var dateTimeResult = Result<DateTimeOffset>.Failure(TestError);
        var testEntityResult = Result<TestEntity>.Failure(TestError);

        // Act
        var intMappedResult = intResult.Map(i => i.ToString());
        var stringMappedResult = stringValueResult.Map(s => s.ToUpper());
        var boolMappedResult = boolResult.Map(b => !b);
        var byteMappedResult = byteResult.Map(b => b * 2);
        var dateTimeMappedResult = dateTimeResult.Map(d => d.AddDays(1));
        var testEntityMappedResult = testEntityResult.Map(e => new TestEntity(e.Id, e.Name));

        // Assert
        intMappedResult.ShouldBeFailureResultWithError(TestError);
        stringMappedResult.ShouldBeFailureResultWithError(TestError);
        boolMappedResult.ShouldBeFailureResultWithError(TestError);
        byteMappedResult.ShouldBeFailureResultWithError(TestError);
        dateTimeMappedResult.ShouldBeFailureResultWithError(TestError);
        testEntityMappedResult.ShouldBeFailureResultWithError(TestError);
    }
}