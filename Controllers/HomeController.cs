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
using HardwareReservationAndAccountingSystem.Enums;

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

            var reservations = _context.Reservations
                    .Include(x => x.Customer)
                    .Include(x => x.EquipmentBundle)
                    .ToList();

            var currentTime = DateTime.Now;
            var today = DateTime.Today;
            var todayEnd = today.AddDays(1);
            var weekEnd = today.AddDays(7);

            var model = new HomeViewModel
            {
                Notifications = _context.Notifications
                    .Where(x => x.NotificationsForUsers.Any(u => u.UserId == user.Id))
                    .Include(x => x.NotificationsForUsers)
                    .OrderBy(x => !x.NotificationsForUsers.Any(n => !n.IsRead && n.UserId == user.Id))
                        .ThenByDescending(x => x.CreatedOn)
                    .Take(10)
                    .ToList(),
                Users = _context.ApplicationUsers
                    .OrderBy(x => x.UserName)
                    .ToList(),
                NotificationTypes = _context.NotificationTypes
                    .Where(x => !x.IsArchived)
                    .OrderBy(x => x.Title)
                    .ToList(),
                ReservationsNewest = reservations
                    .OrderByDescending(x => x.UpdatedOn)
                    .Take(10)
                    .ToList(),
                ReservationsToday = reservations
                    .Where(x => (x.StartTime >= today && x.StartTime <= todayEnd) || (x.EndTime >= today && x.EndTime <= todayEnd))
                    .OrderBy(x => x.StartTime)
                    .ToList(),
                ReservationsWeek = reservations
                    .Where(x => (x.StartTime >= today && x.StartTime <= weekEnd) || (x.EndTime >= today && x.EndTime <= weekEnd))
                    .OrderBy(x => x.StartTime)
                    .ToList(),
                ReservationsOld = reservations
                    .Where(x => today > x.EndTime)
                    .OrderByDescending(x => x.EndTime)
                    .Take(10)
                    .ToList(),
                Events = _context.Events
                    .Where(x => x.EndTime > currentTime)
                    .OrderBy(x => x.StartTime)
                    .Take(10)
                    .ToList(),
                EquipmentBundles = _context.EquipmentBundles
                    .Where(x => x.Status == EquipmentBundleStatus.Public)
                    .ToList()
            };

            return View(model);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
