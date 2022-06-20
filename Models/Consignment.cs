using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsignmentApi.Models;

public class ConsignmentData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("ItemName")]
    [JsonPropertyName("ItemName")]
    public string ItemName { get; set; } = null!;

    public int Quantity { get; set; }

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;
}

