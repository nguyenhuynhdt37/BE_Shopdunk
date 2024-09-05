using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BE_Shopdunk.Dtos.Category
{
    public class CategoryDto
    {
        [BsonId]
        public string? Id { set; get; }
        [BsonRequired]
        public string? Name { get; set; }
        [BsonRequired]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [BsonRequired]
        public string? UserID { get; set; }
        [BsonIgnore]
        public List<Product>? Product { get; set; }
    }
}