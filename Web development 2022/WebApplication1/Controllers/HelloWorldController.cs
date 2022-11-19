using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
