﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Repository;
using Shop.DA;
using Shop.DA.Interfaces;
using Shop.Mapping;

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

        public ActionResult Index(int categoryId)
        {
            var productList = _dataAccess.GetAllEntities();
            return View(productList);
        }

        public FileContentResult GetImage(int id)
        {
            var data = _dataAccess.GetAllEntities().FirstOrDefault(o => o.ProductId == id);
            return new FileContentResult(data.ImageData, "image");
        }
    }
}