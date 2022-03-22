namespace Microsoft.DataTransfer.Cosmos.Interface.Services
{
    public class InMemoryAlphabetStore : IAlphabetStore
    {
        public string GetFirstLetter() =>
            "Alpha";
        
        public List<string> GetAllLetters() =>
            new List<string> { "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot" };
    }
}