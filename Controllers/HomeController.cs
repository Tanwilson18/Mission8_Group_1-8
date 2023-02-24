using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_Group_1_8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group_1_8.Controllers
{
    public class HomeController : Controller
    {
        //// constructor 

        private readonly ILogger<HomeController> _logger;
        private TaskContext TaskContext { get; set; }

        public HomeController(TaskContext varName)
        {
            TaskContext = varName;
        }

        public IActionResult Index()
        {
            return View();
        }

        // addtask route
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = TaskContext.Categories.ToList();

            return View();
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
