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
       
        public async Task<IActionResult> Index(string Search)
        {
            //buscar
            IQueryable<string>nameQuery = from name in _context.Users orderby name.Name select name.Name;

            var user = from users in _context.Users  select users;
            if (!String.IsNullOrEmpty(Search))
            {
                user = user.Where(name => name.Name!.Contains(Search));
            }
            return View(await user.ToListAsync());
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
        public IActionResult Create()
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
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            return View(await _context.Users.FirstOrDefaultAsync(m => m.Id == id));
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, User u)
        {
            _context.Users.Update(u);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        } 
    }
}