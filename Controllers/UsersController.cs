using Microsoft.AspNetCore.Authentication;
using Proyecto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

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

        public async Task<IActionResult>Delete(int? id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //se genera otra action para hacer todo el proceso de eliminado
        // public async Task<IActionResult> Delete2(int? id)
        // {
        //     var user =  await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        //     _context.Users.Remove(user);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction("Index");
        // }        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}