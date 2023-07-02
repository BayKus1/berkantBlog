using Microsoft.AspNetCore.Mvc;

namespace berkantBlog.Controllers
{
    public class LoginController : Controller
    {
        
         public IActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "berkant" && password == "90+")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre yanlış!";
                return View();
            }
        }

    }
}
