using System.Web.Mvc;

namespace Finanse_aspnet_mvc.Controllers {
    [Authorize]
    public class PatternsController : Controller {
        // GET: Patterns
        public ActionResult Index() {
            return View();
        }

        // GET: Patterns/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Patterns/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Patterns/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Patterns/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Patterns/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Patterns/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Patterns/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
