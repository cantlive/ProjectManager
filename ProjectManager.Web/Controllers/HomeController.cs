using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
