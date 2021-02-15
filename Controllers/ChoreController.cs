using homeChores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace homeChores.Controllers
{
    [Authorize]
    public class ChoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chore.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Chore chore)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            _context.Chore.Add(chore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chore.FindAsync(id);

            if(chore == null)
            {
                return NotFound();
            }

            return View(chore);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Chore chore)
        {
            if(id != chore.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _context.Update(chore);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chore
                .FirstOrDefaultAsync(c => c.Id == id);

            if(chore == null)
            {
                return NotFound();
            }

            _context.Remove(chore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}