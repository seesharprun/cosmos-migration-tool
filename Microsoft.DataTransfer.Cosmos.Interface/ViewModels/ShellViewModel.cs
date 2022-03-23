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

            _eventAggregator.GetEvent<UpdateHeaderEvent>().Subscribe(OnUpdateHeader);
            _eventAggregator.GetEvent<UpdateStatusEvent>().Subscribe(OnUpdateStatus);
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Subscribe(OnSetButtonNavigate);
        }

        private void OnUpdateHeader(string parameter) =>
            Header = parameter;

        private void OnUpdateStatus(string parameter) =>
            Status = parameter;

        private void OnSetButtonNavigate((NavigationButton Button, string? ViewName) parameter)
        {
            _ = parameter.Button switch
            {
                NavigationButton.Previous => PreviousNavigationTarget = parameter.ViewName,
                NavigationButton.Next => NextNavigationTarget = parameter.ViewName,
                _ => throw new ArgumentException(nameof(parameter.Button))
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

        private void NavigateExecute(string? parameter)
        {
            if (parameter is not null)
            {
                _regionManager.RequestNavigate(RegionNames.Content, parameter);
                _eventAggregator.GetEvent<UpdateNavigationEvent>().Publish(parameter);
            }
        }

        public bool CanNavigateExecute(string? parameter) =>
            parameter is not null;
    }
}