using Microsoft.DataTransfer.Cosmos.Core.Events;
using Prism.Events;
using Prism.Mvvm;

namespace Microsoft.DataTransfer.Cosmos.Interface.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<UpdateHeaderEvent>().Subscribe(OnUpdateHeader);
        }

        private void OnUpdateHeader(string parameter) =>
            Header = parameter;

        private string _header = "Welcome";
        public string Header
        {
            get => _header;
            set
            {
                if (value is not null)
                {
                    SetProperty<string>(ref _header, value);
                }
            }
        }
    }
}