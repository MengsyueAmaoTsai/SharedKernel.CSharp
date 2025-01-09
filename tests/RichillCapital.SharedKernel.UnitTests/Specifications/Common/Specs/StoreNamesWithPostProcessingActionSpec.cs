using RichillCapital.SharedKernel.Specifications;
using RichillCapital.SharedKernel.Specifications.Builders;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public class StoreNamesWithPostProcessingActionSpec : Specification<Store, string?>
{
    public StoreNamesWithPostProcessingActionSpec() =>
        Query
            .Select(x => x.Name)
             .PostProcessingAction(x => x);
}
