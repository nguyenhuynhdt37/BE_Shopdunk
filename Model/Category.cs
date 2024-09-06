using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class Category
    {
        [BsonId]
        [BsonElement("id")]
        public ObjectId Id { set; get; }
        [BsonRequired]
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonRequired]
        [BsonElement("create_date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [BsonRequired]
        [BsonElement("supplier_id")]
        public ObjectId SupplierId { get; set; }
        [BsonIgnore]
        public List<Product>? Products { get; set; }
    }
}