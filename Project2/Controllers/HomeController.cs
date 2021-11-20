using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.Database;
using Project2.Domains;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext db;

        public HomeController(ILogger<HomeController> logger, DBContext database)
        {
            _logger = logger;
            db = database;
        }

        public IActionResult Index()
        {
            IEnumerable<Images> images = db.images;
            return View(images);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(Images img)
        {
            return View();
        }

        
        public IActionResult delete()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult delete(Images img)
        {
            return View();
        }

        public IActionResult share()
        {
            return View();
        }

        public IActionResult Albums()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
