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

        protected override void RegisterTypes(IContainerRegistry registery)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog catalog)
        {
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.NavigationModule.NavigationModule>();
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.WelcomeModule.WelcomeModule>();
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.SourceModule.SourceModule>();
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.TargetModule.TargetModule>();
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.AdvancedModule.AdvancedModule>();
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.SummaryModule.SummaryModule>();
            catalog.AddModule<Microsoft.DataTransfer.Cosmos.ResultsModule.ResultsModule>();
        }
    }
}