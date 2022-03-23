using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Services;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IStepSource _stepSource;

        public NavigationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IStepSource stepSource)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _stepSource = stepSource;

            _eventAggregator.GetEvent<UpdateNavigationEvent>().Subscribe(OnUpdateNavigation);

            _regionManager.RequestNavigate(RegionNames.Content, ViewNames.Welcome);

            Steps.Clear();
            Steps.AddRange(_stepSource.GetStepAndViewPairs());
        }

        private void OnUpdateNavigation(string? parameter)
        {
            if (parameter is not null)
            {
                CurrentStep = Steps.Single(s => s.View == parameter);
            }
        }

        public ObservableCollection<StepViewPair> Steps { get; private set; } = new();

        private StepViewPair _currentStep = new ("Welcome", ViewNames.Welcome);
        public StepViewPair CurrentStep
        {
            get => _currentStep;
            set
            {
                SetProperty<StepViewPair>(ref _currentStep, value);
                _regionManager.RequestNavigate(RegionNames.Content, value.View);
            }
        }
    }
}