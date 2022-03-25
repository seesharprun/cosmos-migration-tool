namespace Microsoft.DataTransfer.Cosmos.Client.Target
{
    internal interface ICosmosSqlExportManager
    {
        Task<bool> ImportAsync(string connectionString);
    }
}