using Microsoft.DataTransfer.Cosmos.AdvancedModule.Models;

namespace Microsoft.DataTransfer.Cosmos.AdvancedModule.Services
{
    public class ErrorLevelService : IErrorLevelService
    {
        public IEnumerable<ErrorLevel> GetErrorLevels() =>
            Enum.GetValues<ErrorLevel>();
    }
}