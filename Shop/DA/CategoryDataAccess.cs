using System.Collections.Generic;
using DAL;
using DAL.Repository;
using DAL.Repository.Interfaces;
using Shop.DA.Interfaces;
using Shop.Mapping;
using Shop.Models;

namespace Shop.DA
{
    public class CategoryDataAccess : DataAccessBase, ICategoryDataAccess
    {
        private readonly ICategoryRepository _repository;
        public CategoryDataAccess(DtoMapper mapper, CategoryRepository categoryRepository)
            : base(mapper)
        {
            _repository = categoryRepository;
        }

        public IEnumerable<CategoryModel> GetAllEntities()
        {
            var entities = _repository.GetAllEntities();
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(entities);
        }

        public CategoryModel GetEntityById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int AddNewEntity(CategoryModel obj)
        {
            var entity = Mapper.Map<CategoryModel, Category>(obj);
            return _repository.AddNewEntity(entity);
        }

        public void UpdateEntity(CategoryModel obj)
        {
            var entity = Mapper.Map<CategoryModel, Category>(obj);
            _repository.UpdateEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            _repository.DeleteEntity(id);
        }

        public IEnumerable<CategoryModel> GetCategoriesByParentId(int id)
        {
            var result = _repository.GetCategoriesByParentId(id);
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(result);
        }

        public bool IsParentCategory(CategoryModel obj)
        {
            throw new System.NotImplementedException();
        }

        public CategoryModel GetCategoryById(int id)
        {
            var entity = Mapper.Map<Category, CategoryModel>(_repository.GetEntityById(id));
            return entity;
        }
    }
}