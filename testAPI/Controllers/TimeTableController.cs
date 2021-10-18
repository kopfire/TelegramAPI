using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TelegramAPI.Models;
using testAPI.Models;

namespace testAPI.Controllers
{

    public class TimeTableController : Controller
    {
        private readonly TimeTableService db;
        public TimeTableController(TimeTableService context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var timeTables = await db.GetTimeTable();
            var model = new IndexViewModel { TimeTables = timeTables };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TimeTable p)
        {
            if (ModelState.IsValid)
            {
                await db.Create(p);
                return RedirectToAction("TimeTable");
            }
            return View(p);
        }
    }
}
