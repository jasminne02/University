using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace WebApplication6.Controllers
{
    public class APIController : Controller
    {

        public ActionResult Nasa()
        {

            var apiKey = "T7lPpBbIxAwr9GABoU6PQYrDHjgznoikS8GYM5zW";
            var url = "https://api.nasa.gov/planetary/apod?api_key=" + apiKey;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    var body = response.Content.ReadAsStringAsync().Result;
                    JObject data = JObject.Parse(body);

                    ViewData["title"] = data["title"];
                    ViewData["explanation"] = data["explanation"];
                    ViewData["image"] = data["hdurl"];
                    ViewData["date"] = data["date"];
                    ViewData["copyright"] = data["copyright"];

                    ViewBag.result = body;
                }
                else
                {
                    ViewData["title"] = "There was an error.";
                }
            }

            return View();
        }
    }
}