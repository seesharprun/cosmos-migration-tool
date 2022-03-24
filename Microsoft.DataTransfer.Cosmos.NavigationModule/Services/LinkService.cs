using Microsoft.DataTransfer.Cosmos.Core;
using Microsoft.DataTransfer.Cosmos.NavigationModule.Models;

namespace Microsoft.DataTransfer.Cosmos.NavigationModule.Services
{
    public class LinkService : ILinkService
    {
        public IEnumerable<Link> GetLinkData() =>
            new List<Link>
            {
                new Link("Welcome", ViewNames.Welcome, false),
                new Link("Source information", ViewNames.SourceManager, true),
                new Link("Target information", ViewNames.TargetManager, true),
                new Link("Advanced", ViewNames.Advanced, false),
                new Link("Summary", ViewNames.Summary, false),
                new Link("Results", ViewNames.Results, false)
            };
    }
}