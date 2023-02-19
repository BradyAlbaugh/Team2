using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectCars.Models
{
    public class Cars
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Vin { get; set; }
        public string? Year { get; set; }
    }
}
