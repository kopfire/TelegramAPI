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
        private readonly TimeTablesService db;
        public TimeTableController(TimeTablesService context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var timeTables = await db.GetTimeTable("ДИТ311");
            Console.WriteLine(timeTables);
            var model = new IndexViewModel { TimeTables = timeTables };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TimeTables p)
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
