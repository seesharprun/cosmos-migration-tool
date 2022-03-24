using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.SourceModule.Models;

namespace Microsoft.DataTransfer.Cosmos.SourceModule.Services
{
    public class SourceService : ISourceService
    {
        public IEnumerable<Source> GetSourceData() =>
            new List<Source>
            {
                new Source("JSON file(s)", ViewNames.JsonImport),
                new Source("CSV File(s)", ViewNames.CsvImport)
            };
    }
}