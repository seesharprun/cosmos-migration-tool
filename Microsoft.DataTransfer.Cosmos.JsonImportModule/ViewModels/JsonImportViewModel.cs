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

            IsCompressed = false;
        }

        private bool _isCompressed = false;
        public bool IsCompressed
        {
            get => _isCompressed;
            set
            {
                SetProperty<bool>(ref _isCompressed, value);
            }
        }

        // TODO: Do something with this list of items
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
                    ParseFiles(dialog.FileNames)
                );
            }

            IEnumerable<Item> ParseFiles(string[] input)
            {
                foreach (string file in input ?? Enumerable.Empty<string>())
                {
                    // TODO: Implement file checking
                    yield return new Item(ItemType.LocalFile, file);
                }
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
                    UrlSet urlInput = result.Parameters.GetValue<UrlSet>(nameof(UrlSet));

                    Items.AddRange<Item>(
                        ParseUrls(urlInput)
                    );
                }
            });

            IEnumerable<Item> ParseUrls(UrlSet input)
            {
                foreach (string url in input?.Urls ?? Enumerable.Empty<string>())
                {
                    yield return new Item(ItemType.OnlineUrl, url);
                }
            }
        }

        public DelegateCommand AddAzureStorageBlobItemCommand =>
            new(AddAzureStorageBlobItemItemExecute);

        public void AddAzureStorageBlobItemItemExecute()
        {
            _dialogService.ShowDialog(DialogNames.AddAzureStorageBlobDialog, (result) =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    AzureStorageBlobSet blobInput = result.Parameters.GetValue<AzureStorageBlobSet>(nameof(AzureStorageBlobSet));

                    Items.AddRange<Item>(
                        ParseBlobs(blobInput)
                    );
                }
            });

            IEnumerable<Item> ParseBlobs(AzureStorageBlobSet input)
            {
                foreach (AzureStorageBlob blob in input?.Blobs ?? Enumerable.Empty<AzureStorageBlob>())
                {
                    if (blob.PublicBlobEndpoint is not null && blob.SecureBlobEndpoint is not null)
                    {
                        yield return new Item(ItemType.AzureStorageBlob, blob.PublicBlobEndpoint.AbsoluteUri, blob.SecureBlobEndpoint.AbsoluteUri);
                    }
                }
            }
        }
    }
}