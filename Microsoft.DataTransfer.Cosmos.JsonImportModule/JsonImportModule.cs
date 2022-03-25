using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.JsonImportModule.ViewModels;
using Microsoft.DataTransfer.Cosmos.JsonImportModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.JsonImportModule
{
    public class JsonImportModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<JsonImportView>(RegionNames.SourceContent);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddJsonURLDialogView, AddJsonURLDialogViewModel>(DialogNames.AddJsonURLDialog);
            containerRegistry.RegisterDialog<AddJsonAzureStorageBlobDialogView, AddJsonAzureStorageBlobDialogViewModel>(DialogNames.AddJsonAzureStorageBlobDialog);
        }
    }
}