using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Finanse_aspnet_mvc.Models;
using Finanse_aspnet_mvc.Models.Categories;

namespace Finanse_aspnet_mvc.Controllers {
    [Authorize]
    public class CategoriesController : Controller {
        private readonly StackMoneyDb _db = new StackMoneyDb();
        // GET: Categories
        public ActionResult Index() {
            IEnumerable<Category> model = _db.Categories;
            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(SubCategory category) {
            try {
                CategoryBase newCategory = category;
                if (category.ParentCategoryId == 0)
                    newCategory = category.AsCategory();

                _db.CategoriesAndSubCategories.Add(newCategory);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Categories/Edit/5
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int id) {
            var model = _db.CategoriesAndSubCategories.Single(category => category.Id == id);
            return View(model);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                var categoryToRemove = _db.CategoriesAndSubCategories.Single(category => category.Id == id);
                _db.CategoriesAndSubCategories.Remove(categoryToRemove);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        protected override void Dispose(bool disposing) {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}
