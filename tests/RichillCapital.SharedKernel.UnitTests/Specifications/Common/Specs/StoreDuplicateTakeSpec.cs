
using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common;

public sealed class StoreDuplicateTakeSpec : Specification<Store>
{
    public StoreDuplicateTakeSpec() =>
        Query
            .Take(1)
            .Take(2);
}