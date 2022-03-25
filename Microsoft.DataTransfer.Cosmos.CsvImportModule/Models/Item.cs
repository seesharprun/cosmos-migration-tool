namespace Microsoft.DataTransfer.Cosmos.CsvImportModule.Models
{
    public record Item(ItemType Type, string Name, string? Secret = null);
}