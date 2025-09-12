using Microsoft.AspNetCore.Mvc;

namespace StatusWS.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
