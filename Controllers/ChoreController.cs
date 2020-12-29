using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace homeChores.Controllers
{
    public class ChoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}