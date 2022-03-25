namespace Microsoft.DataTransfer.Cosmos.JsonImportModule.Models
{
    public record Item(ItemType Type, string Name, string? Secret = null);
}