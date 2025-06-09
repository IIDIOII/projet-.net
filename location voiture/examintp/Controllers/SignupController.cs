using examintp.Models;
using examintp.Models.examintp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace examintp.Controllers
{
    public class SignupController : Controller
    {
        private readonly AppDbContext _context;

        public SignupController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/AppUser/Register.cshtml"); // explicitly point to the right folder
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                ModelState.AddModelError("", "Username already exists.");
                return View("~/Views/AppUser/Register.cshtml");
            }

            var user = new User
            {
                Username = username,
                PasswordHash = ComputeHash(password),
                Role = "Customer"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login", "Login");
        }

        private string ComputeHash(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
