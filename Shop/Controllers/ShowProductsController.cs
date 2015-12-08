using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Repository;
using Shop.DA;
using Shop.DA.Interfaces;
using Shop.Mapping;
using Shop.Models;

namespace Shop.Controllers
{
    public class ShowProductsController : Controller
    {
        //
        // GET: /Index/
        private readonly IProductDataAccess _dataAccess;

        public ShowProductsController()
        {
            _dataAccess = new ProductDataAccess(new DtoMapper(), new ProductRepository());
        }

        public ActionResult Index(int? categoryId)
        {
            IEnumerable<ProductModel> productList = new List<ProductModel>();
            if (categoryId == null)
                productList = _dataAccess.GetAllEntities();
            else
                productList = _dataAccess.GetProductsByCategoryId((int)categoryId);
            return View(productList);
        }

        public FileContentResult GetImage(int id)
        {
            var data = _dataAccess.GetAllEntities().FirstOrDefault(o => o.ProductId == id);
            return new FileContentResult(data.ImageData, "image");
        }
    }
}
