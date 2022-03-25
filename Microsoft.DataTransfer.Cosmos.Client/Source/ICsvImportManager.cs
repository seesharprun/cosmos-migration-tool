namespace Microsoft.DataTransfer.Cosmos.Client.Source
{
    internal interface ICsvImportManager
    {
        Task<bool> ImportAsync(FileInfo? file);
    }
}