using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Finanse_aspnet_mvc.Models;
using Finanse_aspnet_mvc.Models.Operations;

namespace Finanse_aspnet_mvc.Controllers {
    public class HomeController : Controller {
        StackMoneyDb _db = new StackMoneyDb();
        public ActionResult Index() {
            List<Operation> model = _db.Operations.ToList();
            return View(model);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

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