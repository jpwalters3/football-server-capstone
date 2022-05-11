using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
