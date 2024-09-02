using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonRequired]
        public String? Name { get; set; }
        [BsonRequired]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [BsonRequired]
        public ObjectId CategoryId { get; set; }
    }
}