using Microsoft.DataTransfer.Cosmos.TargetModule.Models;

namespace Microsoft.DataTransfer.Cosmos.TargetModule.Services
{
    public interface ITargetService
    {
        IEnumerable<Target> GetTargetData();
    }
}