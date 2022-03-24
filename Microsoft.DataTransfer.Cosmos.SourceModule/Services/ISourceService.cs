using Microsoft.DataTransfer.Cosmos.SourceModule.Models;

namespace Microsoft.DataTransfer.Cosmos.SourceModule.Services
{
    public interface ISourceService
    {
        IEnumerable<Source> GetSourceData();
    }
}