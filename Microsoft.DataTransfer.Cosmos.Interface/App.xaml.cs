using Microsoft.DataTransfer.Cosmos.Interface.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace Microsoft.DataTransfer.Cosmos.Interface
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell() =>
            Container.Resolve<Shell>();

        protected override void RegisterTypes(IContainerRegistry containerRegistery)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.NavigationModule.NavigationModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.WelcomeModule.WelcomeModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.SourceModule.SourceModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.JsonImportModule.JsonImportModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.CsvImportModule.CsvImportModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.TargetModule.TargetModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.CosmosSqlExportModule.CosmosSqlExportModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.AdvancedModule.AdvancedModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.SummaryModule.SummaryModule>();
            moduleCatalog.AddModule<Microsoft.DataTransfer.Cosmos.ResultsModule.ResultsModule>();
        }
    }
}