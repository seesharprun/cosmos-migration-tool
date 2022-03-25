﻿using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.CsvImportModule.Models;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.CsvImportModule.ViewModels
{
    // TODO: Implement validation
    public class CsvImportViewModel : BindableBase, INavigationAware
    {
        private IDialogService _dialogService;

        public CsvImportViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            NestingSeperator = String.Empty;
            TrimQuotedValues = false;
            TreatUnquotedNullAsString = false;
            UseRegionalFormatSettings = false;
            IsCompressed = false;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        { }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        private string _nestingSeperator = String.Empty;
        public string NestingSeperator
        {
            get => _nestingSeperator;
            set
            {
                SetProperty<string>(ref _nestingSeperator, value);
            }
        }

        private bool _trimQuotedValues = false;
        public bool TrimQuotedValues
        {
            get => _trimQuotedValues;
            set
            {
                SetProperty<bool>(ref _trimQuotedValues, value);
            }
        }

        private bool _treatUnquotedNullAsString = false;
        public bool TreatUnquotedNullAsString
        {
            get => _treatUnquotedNullAsString;
            set
            {
                SetProperty<bool>(ref _treatUnquotedNullAsString, value);
            }
        }

        private bool _useRegionalFormatSettings = false;
        public bool UseRegionalFormatSettings
        {
            get => _useRegionalFormatSettings;
            set
            {
                SetProperty<bool>(ref _useRegionalFormatSettings, value);
            }
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
                Filter = "CSV Files|*.csv",
                DefaultExt = "*.csv"
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
            _dialogService.ShowDialog(DialogNames.AddCsvURLDialog, (result) =>
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
            _dialogService.ShowDialog(DialogNames.AddCsvAzureStorageBlobDialog, (result) =>
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