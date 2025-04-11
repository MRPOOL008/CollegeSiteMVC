using CollegeSiteMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSiteMVC.Controllers
{
    public class AddUserController : Controller
    {
        public IActionResult AddUser()
        {
            return View();
        }

        //add user logic:
        public IActionResult RegisterUser(AddUserModel UserDetails)
        {
            try
            {
                string userName = UserDetails.UserName;
                string password = UserDetails.Password;
                string userRole = UserDetails.UserRole;

                using(HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:7088/");

                    string token = HttpContext.Session.GetString("token");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    string apiUrl = $"api/Register/Register?username={userName}&password={password}&userRole={userRole}";
                    HttpResponseMessage response = client.PostAsync(apiUrl, null).Result;

                    if(response.IsSuccessStatusCode)
                    {
                        string responseData = response.Content.ReadAsStringAsync().Result;

                        ModelState.AddModelError("AddUser", "Inserted success");
                        return View("AddUser");
                    }
                    else
                    {
                        ModelState.AddModelError("AddUser", "Something went wrong");
                        return View("AddUser");
                    }
                }
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("AddUser", "Something went wrong");
                return View("AddUser");
            }
        }
    }
}
