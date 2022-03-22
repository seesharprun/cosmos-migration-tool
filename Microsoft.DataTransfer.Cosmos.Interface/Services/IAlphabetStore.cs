namespace Microsoft.DataTransfer.Cosmos.Interface.Services
{
    public interface IAlphabetStore
    {
        string GetFirstLetter();

        List<string> GetAllLetters();
    }
}