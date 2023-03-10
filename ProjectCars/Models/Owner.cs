using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectCars.Models
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}
