using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Notifications.Include(x => x.NotificationType).ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _context.Notifications.Where(x => x.Id == id).Include(x => x.NotificationType).FirstOrDefault();

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}