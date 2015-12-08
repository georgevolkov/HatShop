using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            return View();
        }
    }
}
