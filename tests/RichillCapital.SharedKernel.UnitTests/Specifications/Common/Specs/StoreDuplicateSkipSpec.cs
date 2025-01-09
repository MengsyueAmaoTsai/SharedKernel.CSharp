
using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common;

public sealed class StoreDuplicateSkipSpec : Specification<Store>
{
    public StoreDuplicateSkipSpec() =>
        Query
            .Skip(1)
            .Skip(2);
}