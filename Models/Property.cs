using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateApi.Models
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = string.Empty;

        public string idOwner { get; set; } = string.Empty;
        public string name { get; set; }
        public string addressProperty { get; set; }
        public decimal priceProperty { get; set; }
        public string image { get; set; }

    }
}
