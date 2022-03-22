using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.ResultsModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.ResultsModule
{
    public class ResultsModule : IModule
    {
        public void OnInitialized(IContainerProvider provider)
        {
            var regionManager = provider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<ResultsView>(RegionNames.Content);
        }

        public void RegisterTypes(IContainerRegistry registry)
        {
        }
    }
}