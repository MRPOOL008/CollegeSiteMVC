using Microsoft.AspNetCore.Mvc;

namespace CollegeSiteMVC.Controllers
{
    public class AddStudentController : Controller
    {
        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
