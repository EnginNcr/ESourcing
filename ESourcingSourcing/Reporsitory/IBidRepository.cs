using System.Collections.Generic;
using System.Threading.Tasks;
using ESourcingSourcing.Entities;

namespace ESourcingSourcing.Reporsitory
{
    public interface IBidRepository
    {
        Task SendBid(Bid bid);
        Task<List<Bid>> GetBidsByAuctionId(string id);
        Task<Bid> GetBidById(string id);
    }
}
