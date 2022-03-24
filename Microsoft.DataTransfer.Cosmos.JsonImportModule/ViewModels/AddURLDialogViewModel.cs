using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Microsoft.DataTransfer.Cosmos.JsonImportModule.ViewModels
{
    public class AddURLDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Add URL(s)";

        public event Action<IDialogResult>? RequestClose;

        public bool CanCloseDialog() =>
            true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        private string _urlInput = String.Empty;
        public string UrlInput
        {
            get => _urlInput;
            set
            {
                SetProperty<string>(ref _urlInput, value);
            }
        }

        public DelegateCommand FinalizeUrlInputCommand =>
            new(FinalizeUrlInputExecute);

        public void FinalizeUrlInputExecute()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("url-input", UrlInput);

            DialogResult result = new(ButtonResult.OK, parameters);

            RequestClose?.Invoke(result);
        }
    }
}