using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESourcingSourcing.Entities
{
    public class Bid
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AuctionId { get; set; }
        public string ProductId { get; set; }
        public string SellerUserName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateedAt { get; set; }

    }
}
