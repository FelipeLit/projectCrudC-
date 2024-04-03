using Microsoft.AspNetCore.Authentication;
using Proyecto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Controllers
{
    public class ProductsController : Controller
    {
        public readonly BaseContext _context;

        public ProductsController (BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Products.FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}