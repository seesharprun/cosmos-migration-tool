using Prism.Events;

namespace Microsoft.DataTransfer.Cosmos.Core.Events
{
    public class UpdateHeadersEvent : PubSubEvent<(string header, string title)> { }
}