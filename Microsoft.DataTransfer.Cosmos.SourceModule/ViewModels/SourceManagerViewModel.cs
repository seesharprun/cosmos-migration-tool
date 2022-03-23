using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.SourceModule.ViewModels
{
    public class SourceManagerViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _eventAggregator;

        public SourceManagerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeaderEvent>().Publish("Source information");
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, ViewNames.Welcome));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, ViewNames.TargetManager));
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private string _title = "Source";
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