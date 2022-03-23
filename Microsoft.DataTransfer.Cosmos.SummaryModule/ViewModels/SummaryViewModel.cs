using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.SummaryModule.ViewModels
{
    public class SummaryViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _eventAggregator;

        public SummaryViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeaderEvent>().Publish("Summary");
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, ViewNames.Advanced));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, ViewNames.Results));
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}