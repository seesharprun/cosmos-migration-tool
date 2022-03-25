using Prism.Events;

namespace Microsoft.DataTransfer.Cosmos.Core.Events
{
    public class ActivateNavigationEvent : PubSubEvent<(string, bool)> { }
}