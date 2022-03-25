using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Microsoft.DataTransfer.Cosmos.TargetModule.Models;
using Microsoft.DataTransfer.Cosmos.TargetModule.Services;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.TargetModule.ViewModels
{
    public class TargetManagerViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private ITargetService _targetService;

        public TargetManagerViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ITargetService targetService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _targetService = targetService;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeadersEvent>().Publish(("Target information", "Specify target information"));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, ViewNames.SourceManager));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, ViewNames.Advanced));

            Targets.Clear();
            Targets.AddRange(_targetService.GetTargetData());
            CurrentTargetView = ViewNames.CosmosSqlSequentialExport;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        public ObservableCollection<Target> Targets { get; private set; } = new();

        private string _currentTargetView = ViewNames.CosmosSqlSequentialExport;
        public string CurrentTargetView
        {
            get => _currentTargetView;
            set
            {
                SetProperty<string>(ref _currentTargetView, value);
                if (value is not null)
                {
                    _regionManager.RequestNavigate(RegionNames.TargetContent, value);
                }
            }
        }
    }
}