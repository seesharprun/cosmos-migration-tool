using Prism.Ioc;
using Prism.Modularity;

namespace Microsoft.DataTransfer.Cosmos.JsonImportServiceModule
{
    public class JsonImportServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IJsonImportService, JsonImportService>();
        }
    }
}