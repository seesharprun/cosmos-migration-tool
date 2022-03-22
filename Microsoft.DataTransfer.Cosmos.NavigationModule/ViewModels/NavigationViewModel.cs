using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IStepSource _stepSource;

        public NavigationViewModel(IRegionManager regionManager, IStepSource stepSource)
        {
            _regionManager = regionManager;
            _stepSource = stepSource;

            _regionManager.RequestNavigate(RegionNames.Content, ViewNames.Welcome);

            Steps.Clear();
            Steps.AddRange(_stepSource.GetStepAndViewPairs());
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