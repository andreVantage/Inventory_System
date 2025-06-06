using Inventory_System.Data;
using Inventory_System.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Inventory_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var createUser = await _context.AddAsync(user);
            if (createUser == null) 
            {
                
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ValidateUser(User user)
        {
            if (user == null) {

                return NotFound();
            }
            if(user.UserName == "admin" && user.Password == "admin")
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {

            return RedirectToAction(nameof(Index));
        }
    }
}
