using System.Web.Mvc;
using Finanse_aspnet_mvc.Models;

namespace Finanse_aspnet_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly StackMoneyDb _db = new StackMoneyDb();
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Operations");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}