using Microsoft.DataTransfer.Cosmos.AdvancedModule.Models;
using Microsoft.DataTransfer.Cosmos.AdvancedModule.Services;
using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.Core.Events;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.AdvancedModule.ViewModels
{
    public class AdvancedViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _eventAggregator;
        private IErrorLevelService _errorLevelService;

        public AdvancedViewModel(IEventAggregator eventAggregator, IErrorLevelService errorLevelService)
        {
            _eventAggregator = eventAggregator;
            _errorLevelService = errorLevelService;
        }

        public bool KeepAlive { get => true; }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<UpdateHeadersEvent>().Publish(("Advanced", "Advanced configuration"));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Previous, ViewNames.TargetManager));
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, null));

            ErrorLevelStrings.Clear();
            ErrorLevelStrings.AddRange(_errorLevelService.GetErrorLevels().Select(e => $"{e}"));
            CurrentErrorLevel = ErrorLevel.None;
            CurrentErrorLevelString =  $"{ErrorLevel.None}";
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        private string _errorLogFile = String.Empty;
        public string ErrorLogFile
        {
            get => _errorLogFile;
            set
            {
                SetProperty<string>(ref _errorLogFile, value);
            }
        }

        public ObservableCollection<string> ErrorLevelStrings { get; private set; } = new();

        private string _currentErrorLevelString = $"{ErrorLevel.None}";
        public string CurrentErrorLevelString
        {
            get => $"{CurrentErrorLevel}";
            set
            {
                SetProperty<string>(ref _currentErrorLevelString, value);

                ErrorLevel errorLevel;
                if (Enum.TryParse<ErrorLevel>(value, out errorLevel))
                {
                    CurrentErrorLevel = errorLevel;
                }
            }
        }

        private ErrorLevel _currentErrorLevel = ErrorLevel.None;
        public ErrorLevel CurrentErrorLevel
        {
            get => _currentErrorLevel;
            set
            {
                SetProperty<ErrorLevel>(ref _currentErrorLevel, value);
            }
        }

        public DelegateCommand SelectLogFileCommand =>
            new(SelectLogFileExecute);

        private void SelectLogFileExecute()
        {
            SaveFileDialog dialog = new()
            {
                Filter = "CSV Files|*.csv",
                DefaultExt = "*.csv"
            };

            if (dialog.ShowDialog() ?? false)
            {
                ErrorLogFile = dialog.FileName;
            }
        }

        public DelegateCommand ActivateNavigationCommand =>
            new(ActivateNavigationExecute);

        private void ActivateNavigationExecute()
        {
            // TODO: This is a placeholder to continue through the wizard
            _eventAggregator.GetEvent<SetButtonNavigateEvent>().Publish((NavigationButton.Next, ViewNames.Summary));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.Summary, true));
            _eventAggregator.GetEvent<ActivateNavigationEvent>().Publish((ViewNames.Results, true));
        }
    }
}