using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // addtask get route
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = TaskContext.Categories.ToList();

            return View();
        }

        // addtask post route
        [HttpPost]
        public IActionResult AddTask(TaskResponse tr)
        {
            // Validation Branch if Model is Valid
            if (ModelState.IsValid)
            {
                TaskContext.Add(tr);
                TaskContext.SaveChanges();

                return View("Confirmation", tr);
            }
            // Reroute back to page if Model is Invalid
            else
            {
                ViewBag.Categories = TaskContext.Responses.ToList();
                return View(tr);
            }

        }

        // Matrix Route
        public IActionResult Matrix()
        {
            var taskResponses = TaskContext.Responses
                .OrderBy(x => x.DueDate)
                .ToList();
            return View(taskResponses);
        }

        // Edit Page Get Route
        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = TaskContext.Categories.ToList();

            var taskresponse = TaskContext.Responses.Single(x => x.TaskId == taskid);

            return View("AddTask", taskresponse);
        }

        // Edit Page Post Route
        [HttpPost]
        public IActionResult Edit(TaskResponse tr)
        {
            TaskContext.Update(tr);
            TaskContext.SaveChanges();

            return RedirectToAction("Matrix");
        }

        // Delete Page Get Route
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var taskresponse = TaskContext.Responses.Single(x => x.TaskId == taskid);
            return View(taskresponse);
        }

        // Delete Page Post Route
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            TaskContext.Responses.Remove(tr);
            TaskContext.SaveChanges();

            return RedirectToAction("Matrix");
        }

        // Complete Route
        public IActionResult Complete(int taskid)
        {
            var taskresponse = TaskContext.Responses.Single(x => x.TaskId == taskid);
            taskresponse.Completed = true;
            TaskContext.Update(taskresponse);
            TaskContext.SaveChanges();
            return RedirectToAction("Matrix");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
