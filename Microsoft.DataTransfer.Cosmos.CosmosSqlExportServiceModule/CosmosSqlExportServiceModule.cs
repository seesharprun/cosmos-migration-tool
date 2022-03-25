using Prism.Ioc;
using Prism.Modularity;

namespace Microsoft.DataTransfer.Cosmos.CosmosSqlExportServiceModule
{
    public class CosmosSqlExportServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICosmosSqlExportService, CosmosSqlExportService>();
        }
    }
}