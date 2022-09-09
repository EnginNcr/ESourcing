using System;
using System.Collections.Generic;
using ESourcingSourcing.Entities;
using MongoDB.Driver;

namespace ESourcingSourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> AuctionCollection)
        {
            bool exist =AuctionCollection.Find(p=>true).Any();
            if (!exist)
            {
                AuctionCollection.InsertManyAsync(GetPreConfiguredAuctions());
            }
        }

        private static IEnumerable<Auction> GetPreConfiguredAuctions()
        {
            return new List<Auction>()
            {
                new Auction()
                {
                    Name="Auction 1",
                    Description="Ac",
                    CreateedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FnishedAt=DateTime.Now.AddDays(10),
                    ProductId="631b2cc81550f67bc8025611",
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 5,
                    Status = (int)status.Active

                },
                new Auction()
                {
                    Name="Auction 2",
                    Description="Ac",
                    CreateedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FnishedAt=DateTime.Now.AddDays(10),
                    ProductId="631b2cc81550f67bc8025611",
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 5,
                    Status = (int)status.Active

                },
                new Auction()
                {
                    Name="Auction 3",
                    Description="Ac",
                    CreateedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FnishedAt=DateTime.Now.AddDays(10),
                    ProductId="631b2cc81550f67bc8025611",
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 5,
                    Status = (int)status.Active

                }
            };
        }
    }
}
