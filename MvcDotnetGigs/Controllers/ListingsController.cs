using Microsoft.AspNetCore.Mvc;

namespace MvcDotnetGigs.Controllers
{
    public class ListingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
