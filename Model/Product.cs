using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("category_id")]
        public ObjectId CategoryId { get; set; }

        [BsonElement("supplier_id")]
        public ObjectId SupplierId { get; set; }

        [BsonElement("variants")]
        public List<Variant>? Variants { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}