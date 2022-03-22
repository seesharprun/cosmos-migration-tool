using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.Services
{
    public interface IStepSource
    {
        IEnumerable<StepViewPair> GetStepAndViewPairs();
    }
}