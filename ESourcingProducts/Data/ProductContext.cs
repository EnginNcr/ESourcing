using ESourcingProducts.Data.interfaces;
using ESourcingProducts.Entities;
using ESourcingProducts.Settings;
using MongoDB.Driver;

namespace ESourcingProducts.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDataBaseSettings settings)
        {
            var client =new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DataBaseName);
            Products = database.GetCollection<Product>(settings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
