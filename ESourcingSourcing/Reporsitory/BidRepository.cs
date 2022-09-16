using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESourcingSourcing.Data;
using ESourcingSourcing.Entities;
using MongoDB.Driver;

namespace ESourcingSourcing.Reporsitory
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _context;
        public BidRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(a => a.AuctionId, id);
            List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();
            bids=bids.OrderByDescending(a=>a.CreateedAt)
                .GroupBy(a=>a.SellerUserName)
                .Select(a=>new Bid
                {
                    AuctionId=a.FirstOrDefault().AuctionId,
                    Price= a.FirstOrDefault().Price,
                    CreateedAt= a.FirstOrDefault().CreateedAt,
                    SellerUserName= a.FirstOrDefault().SellerUserName,
                    ProductId= a.FirstOrDefault().ProductId,
                    Id= a.FirstOrDefault().Id
                })
                .ToList();
            return bids;
        }

        public async Task<Bid> GetBidById(string id)
        {
            List<Bid> bids = await GetBidsByAuctionId(id);
            return bids.OrderByDescending(a => a.Price).FirstOrDefault();
        }

        public async Task SendBid(Bid bid)
        {
            await _context.Bids.InsertOneAsync(bid);
        }
    }
}
