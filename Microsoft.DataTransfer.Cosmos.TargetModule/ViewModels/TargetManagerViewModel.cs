using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.TargetModule.ViewModels
{
    public class TargetManagerViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _eventAggregator;

        public TargetManagerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeaderEvent>().Publish("Target information");
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private string _title = "Target";
        public string Title
        {
            get => _title;
            set
            {
                if (value is not null)
                {
                    SetProperty<string>(ref _title, value);
                }
            }
        }
    }
}