using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroMultiBusiness.Catalog.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureIcon { get; set; }
    }
}
