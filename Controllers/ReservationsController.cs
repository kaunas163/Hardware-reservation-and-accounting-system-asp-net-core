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
            var reservations = _context.Reservations
                .Include(x => x.Customer)
                .Include(x => x.EquipmentBundle)
                .Include(x => x.Event)
                .ToList();

            return View(reservations);
        }

        public IActionResult Details(int id)
        {
            var reservation = _context.Reservations
                .Include(x => x.Customer)
                .Include(x => x.EquipmentBundle).ThenInclude(t => t.EquipmentsInBundles).ThenInclude(b => b.Equipment)
                .Include(x => x.Event)
                .FirstOrDefault(x => x.Id == id);

            if (reservation == null)
            {
                return RedirectToAction("Index");
            }

            return View(reservation);
        }
    }
}