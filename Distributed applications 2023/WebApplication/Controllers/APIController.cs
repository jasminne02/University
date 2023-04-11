using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace WebApplication.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index(string carID)
        {
            if(carID == null || carID == "")
            {
                carID = "Моля въведете номер на колата";
            }

            var url = "https://check.bgtoll.bg/check/vignette/plate/BG/"+carID;

            var webClient = new WebClient();

            var body = webClient.DownloadString(url);

            JObject data = JObject.Parse(body);

            if ((bool)data["ok"])
            {
                // there is a result
                ViewData["number"] = data["vignette"]["vignetteNumber"];
                ViewData["validUntil"] = data["vignette"]["valitidyDateToFormatted"];

                ViewData["body"] = body;
            } else
            {
                ViewData["body"] = "няма намерени резултати за кола с номер" + carID;
            }

            ViewData["body"] = body;

            return View();
        }
    }
}
