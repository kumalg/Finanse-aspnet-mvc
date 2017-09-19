using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Finanse_aspnet_mvc.Models;
using Finanse_aspnet_mvc.Models.Accounts;
using Finanse_aspnet_mvc.Models.Helpers;
using Microsoft.AspNet.Identity;

namespace Finanse_aspnet_mvc.Controllers {
    [Authorize]
    public class AccountsController : Controller {
        StackMoneyDb _db = new StackMoneyDb();
        private IEnumerable<KeyValuePair<string, string>> _colors;

        // GET: Accounts
        public async Task<ActionResult> Index() {
            var model = await _db.Accounts.ToListAsync();
            return View(model);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Accounts/Create
        public ActionResult Create() {
            ViewBag.Colors = _colors ?? (_colors = AppSettingsHelper.GetColors());
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public async Task<ActionResult> Create(AccountPost accountPost) {
            ModelState.Remove(nameof(AccountPost.UserId));

            if (ModelState.IsValid) {
                var account = accountPost.GetAccount();
                account.UserId = User.Identity.GetUserId();

                _db.AccountsAndSubAccounts.Add(account);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
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
