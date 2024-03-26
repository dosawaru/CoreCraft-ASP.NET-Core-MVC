using BookHavenWeb.Data;
using BookHavenWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookHavenWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // Database context

        public CategoryController(ApplicationDbContext db)
        {
            _db = db; // Dependency injection of database context
        }

        // GET: /Category
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories; // Retrieve all categories from the database
            return View(objCategoryList); // Pass the category list to the view
        }

        // GET: /Category/Create
        public IActionResult Create()
        {
            return View(); // Return view for creating a new category
        }

        // POST: /Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj); // Add the new category to the database
                _db.SaveChanges(); // Save changes to the database
                TempData["AddMessage"] = "Category added successfully."; // Set success message for display
                return RedirectToAction("Index"); // Redirect to the category index page
            }

            return View(obj); // If model state is invalid, return to the create category view with validation errors
        }

        // GET: /Category/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // Return 404 Not Found if category ID is invalid
            }
            var categoryFromDb = _db.Categories.Find(id); // Find the category by ID in the database
            return View(categoryFromDb); // Return view for editing the category
        }

        // POST: /Category/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj); // Update the category in the database
                _db.SaveChanges(); // Save changes to the database
                TempData["UpdateMessage"] = "Category updated successfully."; // Set success message for display
                return RedirectToAction("Index"); // Redirect to the category index page
            }

            return View(obj); // If model state is invalid, return to the edit category view with validation errors
        }

        // GET: /Category/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // Return 404 Not Found if category ID is invalid
            }
            var categoryFromDb = _db.Categories.Find(id); // Find the category by ID in the database
            return View(categoryFromDb); // Return view for confirming deletion of the category
        }

        // POST: /Category/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            _db.Categories.Remove(obj); // Remove the category from the database
            _db.SaveChanges(); // Save changes to the database
            TempData["DeleteMessage"] = "Category deleted successfully."; // Set success message for display
            return RedirectToAction("Index"); // Redirect to the category index page
        }
    }
}
