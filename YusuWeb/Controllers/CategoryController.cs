using Microsoft.AspNetCore.Mvc;

namespace YusuWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
