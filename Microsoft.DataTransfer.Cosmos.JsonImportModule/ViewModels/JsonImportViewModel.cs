using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.JsonImportModule.Models;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.JsonImportModule.ViewModels
{
    public class JsonImportViewModel : BindableBase
    {
        private IDialogService _dialogService;

        public JsonImportViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public ObservableCollection<Item> Items { get; private set; } = new();

        public DelegateCommand<Item> RemoveItemCommand =>
            new(RemoveItemExecute);

        public void RemoveItemExecute(Item target)
        {
            Items.Remove(target);
        }

        public DelegateCommand ClearItemsCommand =>
            new(ClearItemsExecute);

        public void ClearItemsExecute()
        {
            Items.Clear();
        }

        public DelegateCommand AddFileItemCommand =>
            new(AddFileItemExecute);

        public void AddFileItemExecute()
        {
            OpenFileDialog dialog = new()
            {
                Multiselect = true,
                Filter = "JSON Documents|*.json",
                DefaultExt = "*.json"
            };

            if (dialog.ShowDialog() ?? false)
            {
                Items.AddRange<Item>(
                    dialog.FileNames.Select(f => new Item(ItemType.LocalFile, f))
                );
            }
        }

        public DelegateCommand AddURLItemCommand =>
            new(AddURLItemItemExecute);

        public void AddURLItemItemExecute()
        {
            _dialogService.ShowDialog(DialogNames.AddURLDialog, (result) =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    string urlInput = result.Parameters.GetValue<string>("url-input");

                    string[] urls = urlInput.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    Items.AddRange<Item>(
                        urls.Select(u => new Item(ItemType.OnlineUrl, u))
                    );
                }
            });
        }
    }
}