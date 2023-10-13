using DataModels.EF;
using DataModels.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.DTO
{
    public class ProductDto : BaseDto
    {
        public async Task<IEnumerable<Product>> GetAll()
            => await Task.FromResult<IEnumerable<Product>>
                (Context.Products
                    .Where(x => !x.IsDeleted)
                    .OrderByDescending(x => x.Updated)
                    .ThenByDescending(x => x.Created)
                );
        public async Task<IEnumerable<Product>> GetAll(string searchString, int searchCategoryId = 0)
            => await Task.FromResult<IEnumerable<Product>>
                (
                    Context.Products
                        .Where(
                            x => !x.IsDeleted
                            && (String.IsNullOrEmpty(searchString) || x.Name.Contains(searchString))
                            && (searchCategoryId == 0 || x.CategoryId == searchCategoryId)
                            )
                        .OrderByDescending(x => x.Updated)
                        .ThenByDescending(x => x.Created)
                );

        public async Task<Product> GetProductById(int id)
            => await Context.Products.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        public async Task<ContextStatus> Create(Product entity)
        {
            try
            {
                entity.Created = DateTime.Now;
                Context.Products.Add(entity);

                await Context.SaveChangesAsync();
                return ContextStatus.Created;
            }
            catch
            {
                return ContextStatus.Error;
            }
        }

        public async Task<ContextStatus> Update(Product entity)
        {
            try
            {
                var existProduct = await Context.Products.FirstOrDefaultAsync(x => x.Id == entity.Id && !x.IsDeleted);
                if (existProduct == null) return ContextStatus.NotExist;

                existProduct.UpdateField(entity);

                await Context.SaveChangesAsync();
                return ContextStatus.Updated;
            }
            catch
            {
                return ContextStatus.Error;
            }
        }

        public async Task<ContextStatus> Delete(int productId)
        {
            try
            {
                var existProduct = await Context.Products.FirstOrDefaultAsync(x => x.Id == productId && !x.IsDeleted);
                if (existProduct == null) return ContextStatus.NotExist;
                existProduct.IsDeleted = true;

                await Context.SaveChangesAsync();
                return ContextStatus.Deleted;
            }
            catch
            {
                return ContextStatus.Error;
            }
        }

    }
}
