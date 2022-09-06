﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ESourcingProducts.Data.interfaces;
using ESourcingProducts.Entities;
using ESourcingProducts.Repositories.İnterfaces;
using MongoDB.Driver;

namespace ESourcingProducts.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _context;
        public ProductRepository(IProductContext context)
        {
            _context = context;
        }
        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq(m => m.id, id);
            DeleteResult deleteResult =await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<Product> GetProduct(string Id)
        {
          return await _context.Products.Find(p=>p.id==Id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
          return await _context.Products.Find(p=>true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.id == product.id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}