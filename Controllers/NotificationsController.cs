using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HardwareReservationAndAccountingSystem.Models;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var notifications = _context.Notifications
                .Include(x => x.NotificationType)
                .Where(x => x.NotificationsForUsers.Any(u => u.User.Id == user.Id))
                .ToList();

            return View(notifications);
        }

        public IActionResult Details(int id)
        {
            var model = _context.Notifications
                .Include(x => x.NotificationType)
                .Include(x => x.Reservation)
                .Include(x => x.Equipment)
                .Include(x => x.EquipmentBundle)
                .Include(x => x.Event)
                .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}