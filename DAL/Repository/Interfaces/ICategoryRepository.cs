
using System.Collections.Generic;

namespace DAL.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        IEnumerable<Category> GetCategoriesByParentId(int id);
    }
}
