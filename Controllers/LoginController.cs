using Inventory_System.Data;
using Inventory_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyDbContext _context;

        public LoginController(MyDbContext context)
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
    }
}
