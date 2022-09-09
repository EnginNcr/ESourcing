using System.Collections.Generic;
using System.Threading.Tasks;
using ESourcingSourcing.Entities;

namespace ESourcingSourcing.Reporsitory
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> GetAuction();
        Task<Auction> GetAuction(string id);
        Task<Auction> GetAuctionByName(string name);
        Task Create(Auction auction);
        Task<bool> Update(Auction auction);
        Task<bool> Delete(string id);

    }
}
