using MongoDB.Bson.Serialization.Attributes;

namespace OurProject.Data.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("username"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Username { get; set; }

        [BsonElement("email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; }

        [BsonElement("password"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Password { get; set; }
    }
}
