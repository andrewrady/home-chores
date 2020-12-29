using homeChores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace homeChores.Controllers
{
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
    }
}