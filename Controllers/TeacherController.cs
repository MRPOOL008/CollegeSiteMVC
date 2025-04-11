using Microsoft.AspNetCore.Mvc;

namespace CollegeSiteMVC.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
