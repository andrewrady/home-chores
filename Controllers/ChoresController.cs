using homeChores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace homeChores.Controllers
{
    [Authorize]
    public class ChoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new AssignChore();
            var availableChore = await _context.Chore.ToListAsync();
            var users = await _context.AppUsers.ToListAsync();
            model.Chores = availableChore.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            model.AppUsers = users.Select(x => new SelectListItem()
            {
                Text = $"{x.FirstName} {x.LastName}",
                Value = x.UserId.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssignChore assignChore)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var chore = await _context.Chore.FirstOrDefaultAsync(x => x.Id == int.Parse(assignChore.Chore));
            var chores = new Chores()
            {
                Name = chore.Name,
                Level = chore.Level,
                UserId = int.Parse(assignChore.User)
            };

            _context.Chores.Add(chores);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}