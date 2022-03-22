using Microsoft.DataTransfer.Cosmos.AdvancedModule.Views;
using Microsoft.DataTransfer.Cosmos.Core;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.AdvancedModule
{
    public class AdvancedModule : IModule
    {
        public void OnInitialized(IContainerProvider provider)
        {
            var regionManager = provider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<AdvancedView>(RegionNames.Content);
        }

        public void RegisterTypes(IContainerRegistry registry)
        {
        }
    }
}