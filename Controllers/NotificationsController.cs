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
                .Where(x => x.NotificationsForUsers.Any(u => u.UserId == user.Id))
                .OrderBy(x => !x.NotificationsForUsers.Any(n => !n.IsRead && n.UserId == user.Id))
                    .ThenByDescending(x => x.CreatedOn)
                .Include(x => x.NotificationType)
                .Include(x => x.NotificationsForUsers).ThenInclude(u => u.User)
                .ToList();

            return View(notifications);
        }

        public IActionResult Details(int id)
        {
            var model = _context.Notifications
                .Include(x => x.NotificationsForUsers).ThenInclude(u => u.User)
                .Include(x => x.NotificationType)
                .Include(x => x.Reservation).ThenInclude(b => b.EquipmentBundle)
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