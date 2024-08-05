using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroMultiBusiness.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscountId { get; set; }
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubtitle { get; set; }
        public string OfferDiscountImageURL { get; set; }
        public string OfferDiscountButtonTitle { get; set; }
    }
}
