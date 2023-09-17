using Books_Collection.Data;
using Books_Collection.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
