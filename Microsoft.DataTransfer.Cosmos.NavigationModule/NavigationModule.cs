using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Services;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider provider)
        {           
            var regionManager = provider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<NavigationView>(RegionNames.Navigation);
        }

        public void RegisterTypes(IContainerRegistry registry)
        {
            registry.Register<IStepSource, StepSource>();
        }
    }
}