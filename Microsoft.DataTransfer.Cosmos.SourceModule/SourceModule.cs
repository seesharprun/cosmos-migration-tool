using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.SourceModule.Services;
using Microsoft.DataTransfer.Cosmos.SourceModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.SourceModule
{
    public class SourceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<SourceManagerView>(RegionNames.Content);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISourceService, SourceService>();
        }
    }
}