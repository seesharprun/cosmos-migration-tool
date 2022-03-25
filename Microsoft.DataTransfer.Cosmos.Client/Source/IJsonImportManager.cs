namespace Microsoft.DataTransfer.Cosmos.Client.Source
{
    internal interface IJsonImportManager
    {
        Task<bool> ImportAsync(FileInfo? file);
    }
}