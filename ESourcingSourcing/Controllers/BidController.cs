using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESourcingSourcing.Entities;
using ESourcingSourcing.Reporsitory;
using Microsoft.AspNetCore.Mvc;

namespace ESourcingSourcing.Controllers
{
    [Route("api/v1[controller]")]
    [ApiController]
    public class BidController:ControllerBase
    {
        private readonly IBidRepository _bidRepository;
        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository; 
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> SendBid([FromBody]Bid bid)
        {
            await _bidRepository.SendBid(bid);
            return Ok();
        }
        [HttpGet("GetBidByActionId")]
        [ProducesResponseType(typeof(IEnumerable<Bid>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidByAuctionId(string id)
        {
            IEnumerable<Bid> bids = await _bidRepository.GetBidsByAuctionId(id);
            return Ok(bids);

        }
        [HttpGet("GetWinnerBid")]
        [ProducesResponseType(typeof(Bid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bid>> GetWinnerBid(string id)
        {
            Bid bid = await _bidRepository.GetBidById(id);
            return Ok();

        }
    }
}
