using Microsoft.AspNetCore.Mvc;
using Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Database;
using Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Models;
using Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Service;

namespace Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;

        public AccountController(AppDbContext context)
        {
            _context = context;
            _passwordService = new PasswordService();
        }

        //Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Register POST
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Check Duplicate UserName
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == model.Username || u.Email == model.Email);

            if(existingUser != null)
            {
                if (_context.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "Username already taken");
                }

                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                }
                return View(model);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email
            };

            user.PasswordHash = _passwordService.HashPassword(user, model.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        //Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if(user != null && _passwordService.VerifyPassword(user, password, user.PasswordHash))
            {
                //Login Success
                return Content("Login Successful!");
            }

            ModelState.AddModelError("", "Invalid Credentials");
            return View();
        }
    }
}
