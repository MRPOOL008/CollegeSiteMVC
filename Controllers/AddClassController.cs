using CollegeSiteMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSiteMVC.Controllers
{
    public class AddClassController : Controller
    {
        public IActionResult AddClass()
        {
            return View();
        }

        //add class logic:
        public IActionResult InsertClass(AddClassModel ClassDetails)
        {
            try
            {
                string ClassName = ClassDetails.ClassName;

                //add class API logic:
                using (HttpClient client = new HttpClient())
                {
                    string? token = HttpContext.Session.GetString("token");
                    string? userRole = HttpContext.Session.GetString("userRole");

                    client.BaseAddress = new Uri("http://localhost:7088/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    string apiUrl = $"/api/AddClass/InsertClass?className={ClassName}";
                    HttpResponseMessage response = client.PostAsync(apiUrl, null).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = response.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError("AddClass", "Class added!");
                    }
                    else
                    {
                        ModelState.AddModelError("AddClass", "Something went wrong!");
                    }
                }
                return RedirectToAction("AddClass", "AddClass");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("AddClass", "AddClass");
            }
        }
    }
}
