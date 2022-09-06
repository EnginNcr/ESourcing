using ESourcingProducts.Entities;
using MongoDB.Driver;

namespace ESourcingProducts.Data.interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products {get}
    }
}
