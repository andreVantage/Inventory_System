using Azure.Core.Pipeline;
using Inventory_System.Data;
using Inventory_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web;
namespace Inventory_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext myDbContext;

        public ProductController(MyDbContext context)
        {
            myDbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var product = await myDbContext.Products.ToListAsync();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {

                product.CreatedAt = DateTime.UtcNow;
                if (ModelState.IsValid)
                {
                    myDbContext.Add(product);
                    await myDbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please Contact the System Administrator");
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await myDbContext.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
        
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await myDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (await TryUpdateModelAsync<Product>(
                product, "",
                p => p.Name, 
                p => p.Description, 
                p => p.Price, 
                p => p.Category, 
                p => p.IsActive
                ))
            {
                try
                {
                    await myDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException )
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id, bool? SaveChangesError = false)
        {
            if (id == null) 
            { 
                return NotFound();
            }
            var product = await myDbContext
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) {
                
                return NotFound();
            }
            if (SaveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. try again and if the problem persists" +
                    "Contact the Systems Administrator.";
            }


            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var product =  await myDbContext.Products.FindAsync(id);

            if (product == null) {

                return RedirectToAction(nameof(Index));
            }
            try
            {
                myDbContext.Products.Remove(product);
                await myDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }catch(DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new {id = id, SaveChangesError = true});
            }

        }
    }
}
