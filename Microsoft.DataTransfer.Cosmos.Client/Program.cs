using Microsoft.DataTransfer.Cosmos.Client.Models;
using Microsoft.DataTransfer.Cosmos.Client.Source;
using Microsoft.DataTransfer.Cosmos.Client.Target;
using Microsoft.DataTransfer.Cosmos.CosmosSqlExportServiceModule;
using Microsoft.DataTransfer.Cosmos.CsvImportServiceModule;
using Microsoft.DataTransfer.Cosmos.JsonImportServiceModule;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            // Example commands
            // --source json --input-file '<file-path>.json' --target cosmossql --target-connection-string 'AccountEndpoint=<cosmos-endpoint>;AccountKey=<cosmos-key>;Database=<cosmos-database>;'
            // --source csv --input-file '<file-path>.csv' --target cosmossql --target-connection-string 'AccountEndpoint=<cosmos-endpoint>;AccountKey=<cosmos-key>;Database=<cosmos-database>;'
            // --source mongo --source-connection-string 'mongodb://<dbuser>:<dbpassword>@<host>:<port>/<database>' --target cosmossql --target-connection-string 'AccountEndpoint=<cosmos-endpoint>;AccountKey=<cosmos-key>;Database=<cosmos-database>;'

            // 1. Print out input values
            RenderInput(source, target, sourceConnectionString, targetConnectionString, inputFile);

            // 2. Register services with DI container
            IServiceProvider container = RegisterServices();

            // 3. Read data from Source using source module
            bool importSuccess = source switch
            {
                DataSource.JSON => await container.GetRequiredService<IJsonImportManager>().ImportAsync(inputFile), 
                DataSource.CSV => await container.GetRequiredService<ICsvImportManager>().ImportAsync(inputFile),
                _ => throw new NotImplementedException($"Data source [{source}] not yet implemented")
            };

            // 4. Transfer data to Target using target module
            bool exportSuccess = target switch
            {
                DataTarget.CosmosSQL => await container.GetRequiredService<ICosmosSqlExportManager>().ImportAsync(targetConnectionString),
                _ => throw new NotImplementedException($"Data target [{target}] not yet implemented")
            };

            // 5. Use colorful console output to render result info
            await Task.CompletedTask;
        }

        private static void RenderInput(DataSource source, DataTarget target, string sourceConnectionString, string targetConnectionString, FileInfo inputFile)
        {
            Console.WriteLine($"Data Source:\t\t\t{source}");
            Console.WriteLine($"\tInput File:\t\t{inputFile?.FullName}");
            Console.WriteLine($"\tConnection String:\t{sourceConnectionString}");

            Console.WriteLine();

            Console.WriteLine($"Data Target:\t\t\t{target}");
            Console.WriteLine($"\tConnection String:\t{targetConnectionString}");
        }

        private static IServiceProvider RegisterServices()
        {
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                        .AddScoped<IJsonImportService, JsonImportService>()
                        .AddScoped<ICsvImportService, CsvImportService>()
                        .AddScoped<ICosmosSqlExportService, CosmosSqlExportService>()
                        .AddScoped<IJsonImportManager, JsonImportManager>()
                        .AddScoped<ICsvImportManager, CsvImportManager>()
                        .AddScoped<ICosmosSqlExportManager, CosmosSqlExportManager>())
                .Build();

            return host.Services;
        }
    }
}