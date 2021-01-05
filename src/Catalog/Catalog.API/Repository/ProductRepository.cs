using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Repository.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        public async Task Create(Product product)
        {
            await catalogContext.Products.InsertOneAsync(product);
        }
        public async Task<bool> Update(Product product)
        {
            var updateResult = await catalogContext.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount>0;
        }
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await catalogContext.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {

            return await catalogContext.Products.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            //FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name,name);
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name,name);
            return await catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await catalogContext.Products.Find(filter).ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await catalogContext.Products.Find(p => true).ToListAsync();
        }

  
    }
}
