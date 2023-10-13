using DataModels.EF;
using DataModels.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.DTO
{
    public class CategoryDto : BaseDto
    {
        public async Task<IEnumerable<Category>> GetAll()
            => await Task.FromResult(Context.Categories.Where(x => !x.IsDeleted));

        public async Task<Category> GetById(int id)
            => await Context.Categories.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        public async Task<ContextStatus> Create(Category entity)
        {
            try
            {
                var findCategory =
                    await Context.Categories.FirstOrDefaultAsync(
                        x =>
                    !x.IsDeleted &&
                    (x.Name.Equals(entity.Name) || x.VietnameseName.Equals(entity.VietnameseName))
                    );
                if (findCategory != null)
                {
                    return ContextStatus.Existed;
                }
                entity.Created = DateTime.Now;

                Context.Categories.Add(entity);
                await Context.SaveChangesAsync();
                return ContextStatus.Created;
            }
            catch
            {
                return ContextStatus.Error;
            }
        }
        public async Task<ContextStatus> Update(Category entity)
        {
            try
            {
                var updateCategory = await Context.Categories.FirstOrDefaultAsync
                (x => !x.IsDeleted && x.Id == entity.Id);
                if (updateCategory == null)
                {
                    return ContextStatus.NotExist;
                }

                //So simple!!!
                updateCategory.Name = entity.Name;
                updateCategory.VietnameseName = entity.VietnameseName;
                updateCategory.Updated = DateTime.Now;
                await Context.SaveChangesAsync();
                return ContextStatus.Updated;
            }
            catch
            {
                return ContextStatus.Error;
            }
        }

        public async Task<ContextStatus> Delete(int id)
        {
            try
            {
                var deleteCategory = await Context.Categories.FirstOrDefaultAsync
                    (x => !x.IsDeleted && x.Id == id);
                if (deleteCategory == null)
                {
                    return ContextStatus.NotExist;
                }

                deleteCategory.IsDeleted = true;
                deleteCategory.Deleted = DateTime.Now;
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
