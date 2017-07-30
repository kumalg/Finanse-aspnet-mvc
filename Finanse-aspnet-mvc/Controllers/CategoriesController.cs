using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
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
            return PartialView("_Details");
        }

        // GET: Categories/Create
        public ActionResult Create() {
            return PartialView("_Create");
        }

        // POST: Categories/Create
        [HttpPost]
        public async Task<ActionResult> Create(SubCategory category) {
            if (ModelState.IsValid) {
                var newCategory = ConvertToRightCategoryType(category);
                _db.CategoriesAndSubCategories.Add(newCategory);
                await _db.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("_Create", category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id) {
            return PartialView("_Edit");
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(SubCategory category) {
            if (ModelState.IsValid) {
                var newCategory = ConvertToRightCategoryType(category);
                _db.Entry(newCategory).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView("_Edit", category);
        }

        // GET: Categories/Delete/5
        public async  Task<ActionResult> Delete(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var category = await _db.CategoriesAndSubCategories.FindAsync(id);

            if (category == null)
                return HttpNotFound();

            return PartialView("_Delete", category);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id) {
            var category = await _db.CategoriesAndSubCategories.FindAsync(id);

            if (category == null)
                return HttpNotFound();

            _db.CategoriesAndSubCategories.Remove(category);
            await _db.SaveChangesAsync();
            return Json(new { success = true });
        }

        private static CategoryBase ConvertToRightCategoryType(SubCategory category) {
            if (category.ParentCategoryId == 0)
                return category.AsCategory();
            return category;
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
