using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.SourceModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.SourceModule
{
    public class SourceModule : IModule
    {
        public void OnInitialized(IContainerProvider provider)
        {
            var regionManager = provider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<SourceManagerView>(RegionNames.Wizard);
        }

        public void RegisterTypes(IContainerRegistry registry)
        {
        }
    }
}