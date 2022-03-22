using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.SummaryModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.SummaryModule
{
    public class SummaryModule : IModule
    {
        public void OnInitialized(IContainerProvider provider)
        {
            var regionManager = provider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<SummaryView>(RegionNames.Content);
        }

        public void RegisterTypes(IContainerRegistry registry)
        {
        }
    }
}