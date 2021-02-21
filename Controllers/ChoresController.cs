using homeChores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace home_chores.Controllers
{
    // [Authorize]
    public class ChoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AssignChore();
            var availableChore = await _context.Chore.ToListAsync();
            var users = await _context.AppUsers.ToListAsync();
            model.Chores = availableChore;
            model.AppUsers = users;

            return View(model);
        }
    }
}