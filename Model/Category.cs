using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { set; get; }
        [BsonRequired]
        public string? Name { get; set; }
        [BsonRequired]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [BsonIgnore]
        public List<User>? Users { get; set; }
    }
}