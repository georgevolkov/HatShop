using System.Collections.Generic;
using System.Linq;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public override IEnumerable<Category> GetAllEntities()
        {
            return DbContext.Categories;
        }

        public override Category GetEntityById(int id)
        {
            return DbContext.Categories.FirstOrDefault(o => o.CategoryId == id);
        }

        public override int AddNewEntity(Category obj)
        {
            DbContext.Categories.Add(obj);
            return DbContext.SaveChanges();
        }

        public override void UpdateEntity(Category obj)
        {
            var entity = GetEntityById(obj.CategoryId);
            entity.CategoryName = obj.CategoryName;
            entity.ParentCategoryId = obj.ParentCategoryId;
            DbContext.SaveChanges();
        }

        public override void DeleteEntity(int id)
        {
            var products = DbContext.Products.Where(o => o.CategoryId == id);
            DbContext.Products.RemoveRange(products);
            var entity = GetEntityById(id);
            DbContext.Categories.Remove(entity);
            DbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategoriesByParentId(int id)
        {
            return DbContext.Categories.Where(o => o.ParentCategoryId == id);
        }
    }
}
