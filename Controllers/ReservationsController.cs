using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;
using Microsoft.AspNetCore.Identity;
using HardwareReservationAndAccountingSystem.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);

            //var notifications = _context.Notifications
            //    .Include(x => x.NotificationType)
            //    .Include(x => x.NotificationsForUsers).ThenInclude(u => u.User)
            //    .Where(x => x.NotificationsForUsers.Any(u => u.User.Id == user.Id))
            //    .ToList();

            var reservations = _context.Reservations
                .Include(x => x.Customer)
                .Include(x => x.EquipmentBundle)
                .Include(x => x.Event)
                .ToList();

            return View(reservations);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}