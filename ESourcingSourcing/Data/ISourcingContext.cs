using ESourcingSourcing.Entities;
using MongoDB.Driver;

namespace ESourcingSourcing.Data
{
    public interface ISourcingContext
    {
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bid> Bids { get; }
    }
}
