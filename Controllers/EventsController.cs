using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var ev = _context.Events
                .Include(x => x.Notifications)
                .FirstOrDefault(x => x.Id == id);

            if (ev == null)
            {
                return RedirectToAction("Index");
            }

            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Location, StartTime, EndTime, Comment")] Event e)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(e);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = e.Id });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id, Title, Location, StartTime, EndTime, Comment")] Event e)
        {
            if (ModelState.IsValid)
            {
                var eventFromDb = _context.Events.Single(x => x.Id == e.Id);

                if (eventFromDb == null)
                {
                    return RedirectToAction(nameof(Details), new { id = e.Id });
                }

                eventFromDb.Title = e.Title;
                eventFromDb.StartTime = e.StartTime;
                eventFromDb.EndTime = e.EndTime;
                eventFromDb.Location = e.Location;
                eventFromDb.Comment = e.Comment;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = e.Id });
            }

            return RedirectToAction(nameof(Details), new { id = e.Id });
        }
    }
}