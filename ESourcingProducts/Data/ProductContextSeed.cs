using System;
using System.Collections.Generic;
using ESourcingProducts.Entities;
using MongoDB.Driver;

namespace ESourcingProducts.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>()
           {
               new Product()
               {
                   Name="huawei",
                   Summary="Telefon",
                   Description="Güzel Telefon",
                   ImageFile=null,
                   Price="650",
                   Category="Telefonlar"
               },
               new Product()
               {
                   Name="Iphone",
                   Summary="Telefon",
                   Description="Güzel Telefon",
                   ImageFile=null,
                   Price="850",
                   Category="Telefonlar"
               },
               new Product()
               {
                   Name="Samsung",
                   Summary="Telefon",
                   Description="Güzel Telefon",
                   ImageFile=null,
                   Price="950",
                   Category="Telefonlar"
               },
               new Product()
               {
                   Name="Oppo",
                   Summary="Telefon",
                   Description="Güzel Telefon",
                   ImageFile=null,
                   Price="450",
                   Category="Telefonlar"
               }
           };
        }
    }
}
