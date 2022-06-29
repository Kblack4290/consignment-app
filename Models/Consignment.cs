using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsignmentApi.Models;

public class ConsignmentData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("FirstName")]
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = null!;

    [BsonElement("LastName")]
    [JsonPropertyName("LastName")]
    public string LastName { get; set; } = null!;

    [BsonElement("Email")]
    [JsonPropertyName("Email")]
    public string Email { get; set; } = null!;

    public string Action { get; set; } = null!;


    [BsonElement("ItemName")]
    [JsonPropertyName("ItemName")]
    public string ItemName { get; set; } = null!;

    public int Quantity { get; set; }

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;
}

