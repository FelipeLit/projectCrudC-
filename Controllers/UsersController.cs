using Microsoft.AspNetCore.Authentication;
using Proyecto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Controllers
{
    public class UsersController: Controller
    {
        public readonly BaseContext _context;

        public UsersController (BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Users.FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}