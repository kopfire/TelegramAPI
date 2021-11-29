using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TelegramAPI.Models;
using TelegramAPI.Repository;

namespace testAPI.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ITimeTableRepository _timeTableService;

        public TimeTableController(ITimeTableRepository context)
        {
            _timeTableService = context;
        }

        public async Task<IActionResult> Index()
        {
            var timeTables = await _timeTableService.GetTimeTableByGroup("ДИНРБ_31/1");
            Console.WriteLine(timeTables);
            var model = new IndexViewModel { TimeTables = timeTables };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> GetGroup(string group)
        {
            var timeTables = await _timeTableService.GetTimeTableByGroup(group);
            Console.WriteLine("кнопка");

            var model = new IndexViewModel { TimeTables = timeTables };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TimeTable p)
        {
            if (ModelState.IsValid)
            {
                await _timeTableService.Create(p);
                return RedirectToAction("TimeTable");
            }
            return View(p);
        }
    }
}
