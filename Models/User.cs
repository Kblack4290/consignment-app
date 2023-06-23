using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsignmentApi.Models;

public class User
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? Id { get; set; } = null!;

    [BsonElement("Email")]
    public string? Email { get; set; } = null!;

    [BsonElement("Password")]

    public string? Password { get; set; } = null!;
}

public class AuthenticatedResponse
{
    public string? Token { get; set; }
}