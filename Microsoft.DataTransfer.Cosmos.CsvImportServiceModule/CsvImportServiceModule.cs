using Prism.Ioc;
using Prism.Modularity;

namespace Microsoft.DataTransfer.Cosmos.CsvImportServiceModule
{
    public class CsvImportServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICsvImportService, CsvImportService>();
        }
    }
}