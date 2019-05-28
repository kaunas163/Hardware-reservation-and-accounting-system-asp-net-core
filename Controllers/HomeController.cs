using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Models;
using HardwareReservationAndAccountingSystem.Data;
using HardwareReservationAndAccountingSystem.ViewsModels.Home;
using Microsoft.EntityFrameworkCore;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var notifications = _context.Notifications
                .Include(x => x.NotificationsForUsers)
                // .Where(x => x.NotificationsForUsers.IsArchived == true)
                // .Where(x => x.NotificationsForUsers.User.UserId == "68736d16-9a33-4471-b5ad-0b018df0b7e8")
                .ToList();

            var model = new HomeViewModel
            {
                Notifications = notifications,
                Reservations = _context.Reservations.ToList(),
                Events = _context.Events.ToList()
            };

            return View(model);
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
