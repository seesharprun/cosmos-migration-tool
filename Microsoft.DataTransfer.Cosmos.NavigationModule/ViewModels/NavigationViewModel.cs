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
        private ILinkService _linkService;

        public NavigationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ILinkService linkService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _linkService = linkService;

            _eventAggregator.GetEvent<UpdateNavigationEvent>().Subscribe(OnUpdateNavigation);

            _regionManager.RequestNavigate(RegionNames.Content, ViewNames.Welcome);

            Links.Clear();
            Links.AddRange(_linkService.GetLinkData());
            CurrentLink = new("Welcome", ViewNames.Welcome, false);
        }

        private void OnUpdateNavigation(string? view)
        {
            if (view is not null)
            {
                CurrentLink = Links.Single(s => s.View == view);
            }
        }

        public ObservableCollection<Link> Links { get; private set; } = new();

        private Link _currentLink = new("Welcome", ViewNames.Welcome, false);
        public Link CurrentLink
        {
            get => _currentLink;
            set
            {
                SetProperty<Link>(ref _currentLink, value);
                _regionManager.RequestNavigate(RegionNames.Content, value.View);
            }
        }
    }
}