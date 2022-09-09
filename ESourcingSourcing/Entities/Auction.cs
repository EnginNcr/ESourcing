﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESourcingSourcing.Entities
{
    public class Auction 
    {
        public  Auction()
        {
            IncludedSellers=new List<string>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FnishedAt { get; set; }
        public DateTime CreateedAt { get; set; }
        public string Status { get; set; }
        public List<string> IncludedSellers { get; set; }
    }
    public enum status
    {
        Active=0,
        Closed=1,
        Passive =2

    }
    

}
