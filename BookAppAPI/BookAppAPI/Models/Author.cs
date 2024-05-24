using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookAppAPI.Models
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = null!;
    }
}
