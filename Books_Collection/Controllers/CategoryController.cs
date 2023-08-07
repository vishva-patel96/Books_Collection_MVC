using Microsoft.AspNetCore.Mvc;

namespace Books_Collection.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
