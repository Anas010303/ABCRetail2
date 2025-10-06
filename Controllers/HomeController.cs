using Microsoft.AspNetCore.Mvc;

namespace ABC_Retail2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
