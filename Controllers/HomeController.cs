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

            var model = new HomeViewModel
            {
                Notifications = _context.Notifications
                    .Where(x => x.NotificationsForUsers.Any(u => u.User.Id == user.Id))
                    .Take(10)
                    .ToList(),
                Reservations = _context.Reservations
                    .Include(x => x.Customer)
                    .Include(x => x.EquipmentBundle)
                    .Take(10)
                    .ToList(),
                Events = _context.Events
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
