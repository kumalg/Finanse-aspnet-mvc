using System.Web.Mvc;
using Finanse_aspnet_mvc.Models;

namespace Finanse_aspnet_mvc.Controllers {
    [Authorize]
    public class AccountsController : Controller {
        StackMoneyDb _db = new StackMoneyDb();
        // GET: Accounts
        public ActionResult Index() {
            var model = _db.Accounts;
            return View(model);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Accounts/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Accounts/Create
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

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Accounts/Edit/5
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

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Accounts/Delete/5
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
