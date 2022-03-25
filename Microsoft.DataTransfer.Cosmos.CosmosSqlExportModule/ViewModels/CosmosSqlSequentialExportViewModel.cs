using Prism.Mvvm;
using Prism.Regions;

namespace Microsoft.DataTransfer.Cosmos.CosmosSqlExportModule.ViewModels
{
    public class CosmosSqlSequentialExportViewModel : BindableBase, INavigationAware
    {
        public CosmosSqlSequentialExportViewModel()
        {
            ConnectionString = String.Empty;
            Container = String.Empty;
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

        private string _connectionString = String.Empty;
        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                SetProperty<string>(ref _connectionString, value);
            }
        }

        private string _container = String.Empty;
        public string Container
        {
            get => _container;
            set
            {
                SetProperty<string>(ref _container, value);
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