using Prism.Mvvm;

namespace Microsoft.DataTransfer.Cosmos.TargetModule.ViewModels
{
    public class TargetManagerViewModel : BindableBase
    {
        private string _title = "Target";
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