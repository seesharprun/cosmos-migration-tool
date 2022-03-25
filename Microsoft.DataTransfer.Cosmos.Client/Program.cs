using Microsoft.DataTransfer.Cosmos.Client.Models;
using Microsoft.DataTransfer.Cosmos.CosmosSqlExportServiceModule;
using Microsoft.DataTransfer.Cosmos.CsvImportServiceModule;
using Microsoft.DataTransfer.Cosmos.JsonImportServiceModule;

namespace Microsoft.DataTransfer.Cosmos.Client
{
    internal class Program
    {
        /// <summary>
        /// Console app to migrate data from a source to a destination
        /// </summary>
        /// <param name="source">Source data type</param>
        /// <param name="target">Target data type</param>
        /// <param name="sourceConnectionString">Source connection string</param>
        /// <param name="targetConnectionString">Target connection string</param>
        /// <param name="inputFile">Input file</param>
        /// <returns></returns>
        static async Task Main(
            DataSource source,
            DataTarget target,
            string sourceConnectionString,
            string targetConnectionString,
            FileInfo inputFile)
        {
            Console.WriteLine($"Data Source:\t\t\t{source}");
            Console.WriteLine($"\tInput File:\t\t{inputFile?.FullName}");
            Console.WriteLine($"\tConnection String:\t{sourceConnectionString}");

            await Console.Out.WriteLineAsync();

            Console.WriteLine($"Data Target:\t\t\t{target}");
            Console.WriteLine($"\tConnection String:\t{targetConnectionString}");

            // --source json --input-file '<file-path>.json' --target cosmossql --target-connection-string 'AccountEndpoint=<cosmos-endpoint>;AccountKey=<cosmos-key>;Database=<cosmos-database>;'
            // --source mongo --source-connection-string 'mongodb://<dbuser>:<dbpassword>@<host>:<port>/<database>' --target cosmossql --target-connection-string 'AccountEndpoint=<cosmos-endpoint>;AccountKey=<cosmos-key>;Database=<cosmos-database>;'

            // 1. Read data from Source using source module

            bool importSuccess = source switch
            {
                DataSource.JSON => ValidateJsonImportConfigured(inputFile) ? HandleJsonImport() : throw new ArgumentException($"Import arguments not provided"),
                DataSource.CSV => ValidateCsvImportConfigured(inputFile) ? HandleCsvImport() : throw new ArgumentException($"Import arguments not provided"),
                _ => throw new NotImplementedException($"Data source [{source}] not yet implemented")
            };

            // 2. Transfer data to Target using target module

            bool exportSuccess = target switch
            {
                DataTarget.CosmosSQL => ValidateCosmosSqlExportConfigured(targetConnectionString) ? HandleCosmosSqlExport() : throw new ArgumentException($"Export arguments not provided"),
                _ => throw new NotImplementedException($"Data target [{target}] not yet implemented")
            };

            // 3. Use colorful console output to render result info
        }

        private static bool ValidateJsonImportConfigured(FileInfo? input) =>
            input?.Exists ?? false;

        private static bool HandleJsonImport()
        {
            JsonImportService jsonImportService = new ();

            // Implement import logic using service

            return true;
        }

        private static bool ValidateCsvImportConfigured(FileInfo? input) =>
            input?.Exists ?? false;

        private static bool HandleCsvImport()
        {
            CsvImportService importService = new ();

            // Implement import logic using service

            return true;
        }

        private static bool ValidateCosmosSqlExportConfigured(string connectionString) =>
            !String.IsNullOrWhiteSpace(connectionString); // TODO: Validate Azure Cosmos DB SQL API connection string

        private static bool HandleCosmosSqlExport()
        {
            CosmosSqlExportService exportService = new ();

            // Implement export logic using service

            return true;
        }
    }
}