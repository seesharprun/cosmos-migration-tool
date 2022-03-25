namespace Microsoft.DataTransfer.Cosmos.Client.Models
{
    /// <summary>
    /// Source of data for migration
    /// </summary>
    public enum DataSource
    {
        /// <summary>
        /// JSON
        /// </summary>
        JSON = 0,
        /// <summary>
        /// CSV
        /// </summary>
        CSV,
        /// <summary>
        /// Azure Cosmos DB SQL API
        /// </summary>
        CosmosSQL,
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