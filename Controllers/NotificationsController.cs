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
using HardwareReservationAndAccountingSystem.ViewsModels.Notifications;

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

            var model = new NotificationsIndex
            {
                Notifications = notifications,
                Users = _context.ApplicationUsers
                    .OrderBy(x => x.UserName)
                    .ToList(),
                NotificationTypes = _context.NotificationTypes
                    .Where(x => !x.IsArchived)
                    .OrderBy(x => x.Title)
                    .ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var notification = _context.Notifications
                .Include(x => x.NotificationsForUsers).ThenInclude(u => u.User)
                .Include(x => x.NotificationType)
                .Include(x => x.Reservation).ThenInclude(b => b.EquipmentBundle)
                .Include(x => x.Equipment)
                .Include(x => x.EquipmentBundle)
                .Include(x => x.Event)
                .FirstOrDefault(x => x.Id == id);

            if (notification == null)
            {
                return RedirectToAction("Index");
            }

            if (notification.NotificationsForUsers
                .Where(u => u.UserId == _userManager.GetUserId(User))
                .Any(x => !x.IsRead))
            {
                var newNotification = notification.NotificationsForUsers
                    .Where(u => u.UserId == _userManager.GetUserId(User))
                    .Single(x => !x.IsRead);

                newNotification.IsRead = true;
            }

            await _context.SaveChangesAsync();

            var model = new NotificationsDetails
            {
                Notification = notification,
                Users = _context.ApplicationUsers
                    .OrderBy(x => x.UserName)
                    .ToList(),
                NotificationTypes = _context.NotificationTypes
                    .Where(x => !x.IsArchived)
                    .OrderBy(x => x.Title)
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificationsDetails viewModel)
        {
            if (ModelState.IsValid)
            {
                var notification = viewModel.Notification;

                notification.CreatedOn = DateTime.Now;
                notification.Sender = await _userManager.GetUserAsync(HttpContext.User);

                _context.Notifications.Add(notification);

                //var userFor = _context.ApplicationUsers.Single(x => x.Id == notification.NotificationsForUsers.Any(x => x.))

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = notification.Id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
