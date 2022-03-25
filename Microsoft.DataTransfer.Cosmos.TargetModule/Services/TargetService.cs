using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.TargetModule.Models;

namespace Microsoft.DataTransfer.Cosmos.TargetModule.Services
{
    public class TargetService : ITargetService
    {
        public IEnumerable<Target> GetTargetData() =>
            new List<Target>
            {
                new Target("Azure Cosmos DB - Sequential record import (partitioned collection)", ViewNames.CosmosSqlSequentialExport),
                new Target("Azure Cosmos DB - Bulk import (single partition collection)", ViewNames.CosmosSqlBulkExport)
            };
    }
}