using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.CosmosSqlExportModule.ViewModels
{
    public class CosmosSqlBulkExportViewModel : BindableBase, INavigationAware
    {
        public CosmosSqlBulkExportViewModel()
        {
            ConnectionString = String.Empty;
            ContainerInput = String.Empty;
            PartitionKey = String.Empty;
            ContainerThroughput = String.Empty;
            UniqueIdentifierFieldName = String.Empty;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        { }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        // TODO: Do something with this list of items
        public ObservableCollection<string> Containers { get; private set; } = new();

        private string _connectionString = String.Empty;
        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                SetProperty<string>(ref _connectionString, value);
            }
        }

        private string _containerInput = String.Empty;
        public string ContainerInput
        {
            get => _containerInput;
            set
            {
                SetProperty<string>(ref _containerInput, value);
            }
        }

        private string _partitionKey = String.Empty;
        public string PartitionKey
        {
            get => _partitionKey;
            set
            {
                SetProperty<string>(ref _partitionKey, value);
            }
        }

        private string _containerThroughput = String.Empty;
        public string ContainerThroughput
        {
            get => _containerThroughput;
            set
            {
                SetProperty<string>(ref _containerThroughput, value);
            }
        }

        private string _uniqueIdentifierFieldName = String.Empty;
        public string UniqueIdentifierFieldName
        {
            get => _uniqueIdentifierFieldName;
            set
            {
                SetProperty<string>(ref _uniqueIdentifierFieldName, value);
            }
        }
    }
}