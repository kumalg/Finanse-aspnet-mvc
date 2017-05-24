using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Finanse_aspnet_mvc.Models;
using Finanse_aspnet_mvc.Models.Operations;

namespace Finanse_aspnet_mvc.Controllers {
    [Authorize]
    public class HomeController : Controller {
        private readonly StackMoneyDb _db = new StackMoneyDb();
        [AllowAnonymous]
        public ActionResult Index() {
            if (!Request.IsAuthenticated)
                return RedirectToAction("About");
            List<Operation> model = _db.Operations.ToList();
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult About() {
            ViewBag.Message = "Chcesz skutecznie zarządzać swoimi finansami? Szukasz funkcjonalnego, lecz prostego w obsłudze narzędzia?";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing) {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}