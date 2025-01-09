using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreWithPostProcessingActionSpec : Specification<Store>
{
    public StoreWithPostProcessingActionSpec() =>
        Query.PostProcessingAction(x => x);
}
