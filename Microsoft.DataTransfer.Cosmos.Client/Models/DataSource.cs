namespace Microsoft.DataTransfer.Cosmos.Client.Models
{
    /// <summary>
    /// Source of data for migration
    /// </summary>
    public enum DataSource
    {
        /// <summary>
        /// Azure Cosmos DB SQL API
        /// </summary>
        CosmosSQL = 0,
        /// <summary>
        /// SQL server or Azure SQL database
        /// </summary>
        SQL,
        /// <summary>
        /// MongoDB
        /// </summary>
        Mongo
    }
}