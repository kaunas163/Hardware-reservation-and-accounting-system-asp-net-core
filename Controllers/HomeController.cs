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
using Microsoft.AspNetCore.Identity;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var notifications = _context.Notifications
                .Where(x => x.NotificationsForUsers.Any(u => u.User.Id == user.Id))
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
