using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookAppAPI.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; } = null!;
        public decimal Price { get; set; }
    }

}
