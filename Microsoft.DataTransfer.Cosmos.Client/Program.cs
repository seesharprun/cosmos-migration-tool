using Microsoft.DataTransfer.Cosmos.Client.Models;

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
        /// <returns></returns>
        static async Task Main(
            DataSource source, 
            DataTarget target, 
            string sourceConnectionString, 
            string targetConnectionString)
        {
            Console.WriteLine($"Data Source:\t{source}");
            Console.WriteLine($"\tConnection String:\t{sourceConnectionString}");
            
            await Console.Out.WriteLineAsync();

            Console.WriteLine($"Data Target:\t{target}");
            Console.WriteLine($"\tConnection String:\t{targetConnectionString}");

            // --source mongo --target cosmossql --source-connection-string 'mongodb://<dbuser>:<dbpassword>@<host>:<port>/<database>' --target-connection-string 'AccountEndpoint=<cosmos-endpoint>;AccountKey=<cosmos-key>;Database=<cosmos-database>;'
        }
    }    
}