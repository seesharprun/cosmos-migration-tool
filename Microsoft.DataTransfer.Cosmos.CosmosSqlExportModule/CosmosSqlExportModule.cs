using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.CosmosSqlExportModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.CosmosSqlExportModule
{
    public class CosmosSqlExportModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<CosmosSqlSequentialExportView>(RegionNames.TargetContent);
            regionManager.RegisterViewWithRegion<CosmosSqlBulkExportView>(RegionNames.TargetContent);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        { }
    }
}