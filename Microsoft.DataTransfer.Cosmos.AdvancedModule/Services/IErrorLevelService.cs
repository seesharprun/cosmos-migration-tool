using Microsoft.DataTransfer.Cosmos.AdvancedModule.Models;

namespace Microsoft.DataTransfer.Cosmos.AdvancedModule.Services
{
    public interface IErrorLevelService
    {
        IEnumerable<ErrorLevel> GetErrorLevels();
    }
}