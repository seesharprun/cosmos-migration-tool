using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Diagnostics;

namespace Microsoft.DataTransfer.Cosmos.WelcomeModule.ViewModels
{
    public class WelcomeViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        public WelcomeViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext context)
            => true;

        public void OnNavigatedTo(NavigationContext context)
        {
            _eventAggregator.GetEvent<UpdateHeadersEvent>().Publish(("Welcome", "Azure Cosmos DB Data Migration Tool"));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, null));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, ViewNames.SourceManager));
        }

        public void OnNavigatedFrom(NavigationContext context)
        {
        }

        public DelegateCommand<string> NavigateBrowserCommand => 
            new (NavigateBrowserExecute);

        private void NavigateBrowserExecute(string destination)
        {
            if (Uri.TryCreate(destination, UriKind.Absolute, out _))
            {
                ProcessStartInfo process = new ("cmd", $"/c start {destination}") { CreateNoWindow = true };
                Process.Start(process);
            }
        }
    }
}