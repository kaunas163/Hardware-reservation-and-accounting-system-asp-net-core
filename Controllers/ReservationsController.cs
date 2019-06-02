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
using HardwareReservationAndAccountingSystem.Enums;
using HardwareReservationAndAccountingSystem.ViewsModels.Reservations;

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

            var bundles = _context.EquipmentBundles
                .Where(x => x.Status == EquipmentBundleStatus.Public)
                .ToList();

            var model = new ReservationsIndex
            {
                Reservations = reservations,
                EquipmentBundles = bundles
            };

            return View(model);
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

            var bundles = _context.EquipmentBundles
                .Where(x => x.Status == EquipmentBundleStatus.Public)
                .ToList();

            var users = _context.ApplicationUsers.ToList();

            var model = new ReservationNewOrUpdate
            {
                Reservation = reservation,
                EquipmentBundles = bundles,
                Users = users
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationNewOrUpdate viewModel)
        {
            ModelState.Remove("Reservation.CustomerId");

            //string messages = string.Join("; ", ModelState.Values
            //                            .SelectMany(x => x.Errors)
            //                            .Select(x => x.ErrorMessage));

            //return Content(messages);

            if (ModelState.IsValid)
            {
                var reservation = viewModel.Reservation;

                var current = DateTime.Now;
                reservation.CreatedOn = current;
                reservation.UpdatedOn = current;

                var selectedBundleId = Request.Form["equipmentBundles"];

                if (!selectedBundleId.Any())
                {
                    return RedirectToAction(nameof(Index));
                }

                var bundle = _context.EquipmentBundles.Single(x => x.Id == Convert.ToInt32(selectedBundleId.FirstOrDefault()));

                if (bundle == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                reservation.EquipmentBundle = bundle;

                var user = await _userManager.GetUserAsync(HttpContext.User);
                reservation.CustomerId = user.Id;

                reservation.Status = ReservationStatus.Pending;

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = reservation.Id });
            }
           
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> EditStatus([Bind("Id", "Status")] Reservation reservation)
        {
            var reservationInDb = _context.Reservations.Single(x => x.Id == reservation.Id);

            if (reservationInDb == null)
            {
                return RedirectToAction(nameof(Index));
            }

            reservationInDb.Status = reservation.Status;
            reservationInDb.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = reservation.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ReservationNewOrUpdate viewModel)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}