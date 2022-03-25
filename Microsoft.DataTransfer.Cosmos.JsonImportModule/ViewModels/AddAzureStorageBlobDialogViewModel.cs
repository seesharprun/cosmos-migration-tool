using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.DataTransfer.Cosmos.JsonImportModule.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Microsoft.DataTransfer.Cosmos.JsonImportModule.ViewModels
{
    internal class AddAzureStorageBlobDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Add Azure Storage Blob(s)";

        public event Action<IDialogResult>? RequestClose;

        public bool CanCloseDialog() =>
            true;

        public void OnDialogClosed()
        { }

        public void OnDialogOpened(IDialogParameters parameters)
        { }

        private string _connectionString = String.Empty;
        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                SetProperty<string>(ref _connectionString, value);
            }
        }

        private string _containerName = String.Empty;
        public string ContainerName
        {
            get => _containerName;
            set
            {
                SetProperty<string>(ref _containerName, value);
            }
        }

        private string _blobName = String.Empty;
        public string BlobName
        {
            get => _blobName;
            set
            {
                SetProperty<string>(ref _blobName, value);
            }
        }

        public DelegateCommand FinalizeAzureStorageBlobInputCommand =>
            new DelegateCommand(FinalizeAzureStorageBlobInputExecute, FinalizeAzureStorageBlobInputCanExecute)
                .ObservesProperty<string>(() => ConnectionString)
                .ObservesProperty<string>(() => ContainerName)
                .ObservesProperty<string>(() => BlobName);

        public bool FinalizeAzureStorageBlobInputCanExecute() =>
            !String.IsNullOrWhiteSpace(ConnectionString) &&
            !String.IsNullOrWhiteSpace(ContainerName) &&
            !String.IsNullOrWhiteSpace(BlobName);

        public async void FinalizeAzureStorageBlobInputExecute()
        {
            DialogParameters parameters = new DialogParameters();

            BlobClient client = new(ConnectionString, ContainerName, BlobName);
            // TODO: Catch RequestFailedException (wrong connection string)
            if (await client.ExistsAsync())
            {
                Uri publicUri = client.Uri;
                BlobSasBuilder secureBuilder = new(BlobContainerSasPermissions.Read, DateTimeOffset.Now.AddHours(1d));
                Uri secureUri = client.GenerateSasUri(secureBuilder);

                AzureStorageBlob blob = new AzureStorageBlob(publicUri, secureUri);

                AzureStorageBlobSet output = new(blob);

                parameters.Add(nameof(AzureStorageBlobSet), output);
            }
            else
            {
                // TODO: Warn user that blob could not be found
            }

            DialogResult result = new(ButtonResult.OK, parameters);

            RequestClose?.Invoke(result);
        }
    }
}