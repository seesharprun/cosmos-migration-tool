using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.ResultsModule.ViewModels
{
    // TODO: Implement "New Import" button and reset all viewmodels
    public class ResultsViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _eventAggregator;

        public ResultsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeadersEvent>().Publish(("Results", "Import results"));
            _eventAggregator.GetEvent<UpdateStatusEvent>().Publish("Congratulations on your migration!");
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, null));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, null));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.Welcome, false));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.SourceManager, false));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.TargetManager, false));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.Advanced, false));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.Summary, false));
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }
    }
}