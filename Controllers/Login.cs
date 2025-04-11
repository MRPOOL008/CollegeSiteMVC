using CollegeSiteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CollegeSiteMVC.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }


        public IActionResult login(LoginModel loginDetails)
        {
            string email = loginDetails.Email;
            string password = loginDetails.Password;


            //login API concept:
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:7088/");

                string apiUrl = $"api/Login/Login?userEmail={email}&password={password}";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON response
                    //JavasriptSerializer js = new JavasriptSerializer();
                    //var jsonResponse = js.Deserialize<dynamic>(responseData);
                    var jsonResponse = JsonSerializer.Deserialize<Dictionary<string, string>>(responseData);

                    // Extract token and role from API response
                    string token = jsonResponse["token"];
                    string userRole = jsonResponse["userRole"];

                    //session set values
                    HttpContext.Session.SetString("token", token);
                    HttpContext.Session.SetString("userRole", userRole);

                    if(userRole == "Admin")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else if(userRole == "Teacher")
                    {
                        return RedirectToAction("Dashboard", "Teacher");
                    }
                    else if(userRole == "Student")
                    {
                        return RedirectToAction("Dashboard", "Student");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "User role was not found!");
                        return View("Login");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login", "User with this email was not found!");
                    return View("Login");
                }

            }
        }
    }
}
