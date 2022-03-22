using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.Services
{
    public class StepSource : IStepSource
    {
        public IEnumerable<StepViewPair> GetStepAndViewPairs() =>
            new List<StepViewPair>
            {
                new StepViewPair("Welcome", ViewNames.Welcome),
                new StepViewPair("Source information", ViewNames.SourceManager),
                new StepViewPair("Target information", ViewNames.TargetManager),
                new StepViewPair("Advanced", ViewNames.Advanced),
                new StepViewPair("Summary", ViewNames.Summary),
                new StepViewPair("Results", ViewNames.Results)
            };
    }
}