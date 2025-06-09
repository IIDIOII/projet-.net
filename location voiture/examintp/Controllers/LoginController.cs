using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using examintp.Models;
namespace examintp.Controllers
{
    public class LoginController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        // Show the login form
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/AppUser/Login.cshtml");
        }

        // Process login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var hash = HashHelper.ComputeHash(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View("~/Views/AppUser/Login.cshtml");
            }

            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Home");
        }
    }

    }
