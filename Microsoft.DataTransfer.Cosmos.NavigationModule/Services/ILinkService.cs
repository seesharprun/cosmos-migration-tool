using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.Services
{
    public interface ILinkService
    {
        IEnumerable<Link> GetLinkData();
    }
}