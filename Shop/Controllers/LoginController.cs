using System;
using System.Web.Mvc;
using Shop.DA.Interfaces;
using Shop.Models;
using Shop.Validators;

namespace Shop.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            if (!UserValidator.UserEmptyLoginValidate(model, this.ModelState))
                return PartialView("_LoginPartial");

            Session["UserName"] = model.UserName;
            return Json(new {success = true});
        }

        [HttpPost]
        public JsonResult Login(UserModel model)
        {
            var categoryList = new JsonResult();
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }
    }
}
