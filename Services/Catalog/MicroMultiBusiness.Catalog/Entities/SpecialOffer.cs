using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroMultiBusiness.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageURL { get; set; }
    }
}
