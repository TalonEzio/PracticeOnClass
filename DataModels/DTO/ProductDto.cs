using DataModels.EF;
using DataModels.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataModels.DTO
{
    public class ProductDto : BaseDto
    {
        public async Task<IEnumerable<Product>> GetAll()
            => await Task.FromResult<IEnumerable<Product>>(Context.Products);
        public async Task<Product> GetProductById(int id)
            => await Context.Products.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        public async Task<ProductStatus> Create(Product entity)
        {
            try
            {
                entity.Created = DateTime.Now;
                Context.Products.Add(entity);

                await Context.SaveChangesAsync();
                return ProductStatus.Created;
            }
            catch
            {
                return ProductStatus.Error;
            }
        }

        public async Task<ProductStatus> Update(Product entity)
        {
            try
            {
                var existProduct = await Context.Products.FirstOrDefaultAsync(x => x.Id == entity.Id && !x.IsDeleted);
                if (existProduct == null) return ProductStatus.NotExist;

                existProduct.UpdateNew(entity);

                await Context.SaveChangesAsync();
                return ProductStatus.Updated;
            }
            catch
            {
                return ProductStatus.Error;
            }
        }

        public async Task<ProductStatus> Delete(int productId)
        {
            try
            {
                var existProduct = await Context.Products.FirstOrDefaultAsync(x => x.Id == productId && !x.IsDeleted);
                if (existProduct == null) return ProductStatus.NotExist;
                existProduct.IsDeleted = true;

                await Context.SaveChangesAsync();
                return ProductStatus.Deleted;
            }
            catch
            {
                return ProductStatus.Error;
            }
        }

    }
}
