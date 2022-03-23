using Prism.Events;

namespace Microsoft.DataTransfer.Cosmos.Core.Events
{
    public class SetButtonNavigateEvent : PubSubEvent<(NavigationButton, string?)> { }
}