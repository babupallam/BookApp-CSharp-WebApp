namespace BookAppAPI.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string BooksCollectionName { get; set; } = null!;
        public string AuthorsCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface IDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string AuthorsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
