using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Microsoft.DataTransfer.Cosmos.SourceModule.Models;
using Microsoft.DataTransfer.Cosmos.SourceModule.Services;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.SourceModule.ViewModels
{
    public class SourceManagerViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private ISourceService _sourceService;

        public SourceManagerViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ISourceService sourceService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _sourceService = sourceService;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeadersEvent>().Publish(("Source information", "Specify source information"));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, ViewNames.Welcome));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, ViewNames.TargetManager));

            Sources.Clear();
            Sources.AddRange(_sourceService.GetSourceData());
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public ObservableCollection<Source> Sources { get; private set; } = new ();

        private string _currentSourceView = ViewNames.JsonImport;
        public string CurrentSourceView
        {
            get => _currentSourceView;
            set
            {
                SetProperty<string>(ref _currentSourceView, value);
                if (value is not null)
                {
                    _regionManager.RequestNavigate(RegionNames.SourceContent, value);
                }
            }
        }
    }
}