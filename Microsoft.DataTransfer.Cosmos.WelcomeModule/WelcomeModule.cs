using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.WelcomeModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.WelcomeModule
{
    public class WelcomeModule : IModule
    {
        public void OnInitialized(IContainerProvider provider)
        {
            var regionManager = provider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<WelcomeView>(RegionNames.Content);
        }

        public void RegisterTypes(IContainerRegistry registry)
        {
        }
    }
}