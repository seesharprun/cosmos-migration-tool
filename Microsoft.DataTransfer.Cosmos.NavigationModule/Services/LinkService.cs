using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.Services
{
    public class LinkService : ILinkService
    {
        public IEnumerable<Link> GetLinkData() =>
            new List<Link>
            {
                new Link("Welcome", ViewNames.Welcome, false, true),
                new Link("Source information", ViewNames.SourceManager, true, true),
                new Link("Target information", ViewNames.TargetManager, true, true),
                new Link("Advanced", ViewNames.Advanced, false, true),
                new Link("Summary", ViewNames.Summary, false, false),
                new Link("Results", ViewNames.Results, false, false)
            };
    }
}