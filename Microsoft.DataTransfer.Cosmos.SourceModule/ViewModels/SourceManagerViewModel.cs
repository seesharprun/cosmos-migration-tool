using Prism.Mvvm;

namespace Microsoft.DataTransfer.Cosmos.SourceModule.ViewModels
{
    public class SourceManagerViewModel : BindableBase
    {
        private string _title = "Source";
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