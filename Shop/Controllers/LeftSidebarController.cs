using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Repository;
using Newtonsoft.Json;
using Shop.DA;
using Shop.DA.Interfaces;
using Shop.Mapping;
using Shop.Models;

namespace Shop.Controllers
{
    public class LeftSidebarController : Controller
    {
        private readonly ICategoryDataAccess _dataAccess;
        private readonly IProductDataAccess _productDataAccess;
        public LeftSidebarController()
        {
            _dataAccess = new CategoryDataAccess(new DtoMapper(), new CategoryRepository());
            _productDataAccess = new ProductDataAccess(new DtoMapper(), new ProductRepository());
        }

        public ActionResult Index()
        {
            var model = new LeftSideBarModel {CategoryModel = GetZeroLevelCategories()};
            return View(model);
        }

        private List<ZeroLevelCategotyModel> GetZeroLevelCategories()
        {
            var zeroLevelCategories = new List<ZeroLevelCategotyModel>();
            foreach (var model in _dataAccess.GetAllEntities().Where(o => o.ParentCategoryId == null))
            {
                var zeroLevelCategory = new ZeroLevelCategotyModel
                {
                    ZeroLevelModel = model,
                    FirstLevelCategoies = GetFirstLevelCategoryModel(model),
                    ProductCount = _productDataAccess.GetProductsByCategoryId(model.CategoryId).Count()
                };
                zeroLevelCategories.Add(zeroLevelCategory);
            }
            return zeroLevelCategories;
        }

        private List<SecondLevelCategoryModel> GetSecondLevelCategoryModel(CategoryModel fisrtLevel)
        {
            var result = new List<SecondLevelCategoryModel>();
            foreach (var categoryModel in _dataAccess.GetCategoriesByParentId(fisrtLevel.CategoryId))
            {
                var item = new SecondLevelCategoryModel
                {
                    SecondLevelCategory = categoryModel,
                    ProductCount = _productDataAccess.GetProductsByCategoryId(categoryModel.CategoryId).Count()
                };
                result.Add(item);
            }
            return result;
        }

        private List<FirstLevelCategoryModel> GetFirstLevelCategoryModel(CategoryModel topLevel)
        {
            var result = new List<FirstLevelCategoryModel>();
            foreach (var categoryModel in _dataAccess.GetCategoriesByParentId(topLevel.CategoryId))
            {
                var item = new FirstLevelCategoryModel
                {
                    FirstLevelCategory = categoryModel,
                    SecondLevelCategories = GetSecondLevelCategoryModel(categoryModel),
                    ProductCount = _productDataAccess.GetProductsByCategoryId(categoryModel.CategoryId).Count()
                };
                result.Add(item);
            }
            return result;
        }
    }
}