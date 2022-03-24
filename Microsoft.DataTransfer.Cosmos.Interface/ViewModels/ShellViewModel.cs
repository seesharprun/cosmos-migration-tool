using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.Interface.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManager;

        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            _eventAggregator.GetEvent<UpdateHeadersEvent>().Subscribe(OnUpdateHeaders);
            _eventAggregator.GetEvent<UpdateStatusEvent>().Subscribe(OnUpdateStatus);
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Subscribe(OnSetButtonNavigate);
        }

        private void OnUpdateHeaders((string Header, string Title) payload)
        {
            Header = payload.Header;
            Title = payload.Title;
        }

        private void OnUpdateStatus(string status) =>
            Status = status;

        private void OnSetButtonNavigate((NavigationButton Button, string? ViewName) payload)
        {
            _ = payload.Button switch
            {
                NavigationButton.Previous => PreviousNavigationTarget = payload.ViewName,
                NavigationButton.Next => NextNavigationTarget = payload.ViewName,
                _ => throw new ArgumentException(nameof(payload.Button))
            };
        }

        private string? _header = "Welcome";
        public string? Header
        {
            get => _header;
            set
            {
                SetProperty<string>(ref _header!, value!);
            }
        }

        private string? _title = "Azure Cosmos DB Data Migration Tool";
        public string? Title
        {
            get => _title;
            set
            {
                SetProperty<string>(ref _title!, value!);
            }
        }

        private string? _status = null;
        public string? Status
        {
            get => _status;
            set
            {
                SetProperty<string>(ref _status!, value!);
            }
        }

        private string? _previousNavigationTarget = null;
        public string? PreviousNavigationTarget
        {
            get => _previousNavigationTarget;
            set
            {
                SetProperty<string?>(ref _previousNavigationTarget!, value!);
            }
        }

        private string? _nextNavigationTarget = ViewNames.SourceManager;
        public string? NextNavigationTarget
        {
            get => _nextNavigationTarget;
            set
            {
                SetProperty<string?>(ref _nextNavigationTarget!, value!);
            }
        }

        public DelegateCommand<string?> NavigateCommand =>
            new DelegateCommand<string?>(NavigateExecute, CanNavigateExecute)
                .ObservesProperty<string?>(() => NextNavigationTarget)
                .ObservesProperty<string?>(() => PreviousNavigationTarget);

        private void NavigateExecute(string? view)
        {
            if (view is not null)
            {
                _regionManager.RequestNavigate(RegionNames.Content, view);
                _eventAggregator.GetEvent<UpdateNavigationEvent>().Publish(view);
            }
        }

        public bool CanNavigateExecute(string? view) =>
            view is not null;
    }
}