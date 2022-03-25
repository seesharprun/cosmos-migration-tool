using Microsoft.DataTransfer.Cosmos.CosmosSqlExportServiceModule;

namespace Microsoft.DataTransfer.Cosmos.Client.Target
{
    internal class CosmosSqlExportManager: ICosmosSqlExportManager
    {
        private readonly ICosmosSqlExportService _cosmosSqlExportService;

        public CosmosSqlExportManager(ICosmosSqlExportService cosmosSqlExportService)
        {
            _cosmosSqlExportService = cosmosSqlExportService;
        }

        public async Task<bool> ImportAsync(string connectionString)
        {
            if (!ValidateInput(connectionString))
            {
                throw new ArgumentException($"Cosmos SQL export arguments not provided");
            }

            // Implement import logic using _cosmosSqlExportService
            await Task.CompletedTask;

            return true;
        }

        private bool ValidateInput(string connectionString) =>
            !String.IsNullOrWhiteSpace(connectionString); // TODO: Validate Azure Cosmos DB SQL API connection string
    }
}