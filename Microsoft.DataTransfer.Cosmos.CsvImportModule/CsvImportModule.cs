using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.CsvImportModule.ViewModels;
using Microsoft.DataTransfer.Cosmos.CsvImportModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.CsvImportModule
{
    public class CsvImportModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<CsvImportView>(RegionNames.SourceContent);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddCsvURLDialogView, AddCsvURLDialogViewModel>(DialogNames.AddCsvURLDialog);
            containerRegistry.RegisterDialog<AddCsvAzureStorageBlobDialogView, AddCsvAzureStorageBlobDialogViewModel>(DialogNames.AddCsvAzureStorageBlobDialog);
        }
    }
}