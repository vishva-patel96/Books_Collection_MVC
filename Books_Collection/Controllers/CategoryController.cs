using Books_Collection.Data;
using Books_Collection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Books_Collection.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _db;
        //get data from Categories table
        public CategoryController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //HttpGet method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //Custom validation
            if (category.DisplayOrder.ToString() == category.Name)
            {
                ModelState.AddModelError("name", "DisplayOrder cannot exactly match the Name.");
            }
            Category CategoryfromDB = _db.Categories.FirstOrDefault(c => c.Name == category.Name);
            if(CategoryfromDB != null &&  CategoryfromDB.Name == category.Name)
            {
                ModelState.AddModelError("Name", "Name is already exist");
            }

            //server-side validation
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryIDFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (CategoryIDFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryIDFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //server-side validation
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
