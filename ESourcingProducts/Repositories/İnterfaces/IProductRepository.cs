using System.Collections.Generic;
using System.Threading.Tasks;
using ESourcingProducts.Entities;

namespace ESourcingProducts.Repositories.İnterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string Id);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryName);
        Task Create(Product product);
        Task    <bool> Update(Product product);
        Task    <bool> Delete(string id);
    }
}
