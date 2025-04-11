using Microsoft.AspNetCore.Mvc;

namespace CollegeSiteMVC.Controllers
{
    public class AddTeacherController : Controller
    {
        public IActionResult AddTeacher()
        {
            return View();
        }
    }
}
