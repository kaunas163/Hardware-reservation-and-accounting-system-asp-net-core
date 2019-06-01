using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;
using Microsoft.EntityFrameworkCore;
using HardwareReservationAndAccountingSystem.Enums;
using HardwareReservationAndAccountingSystem.Models;
using System.Threading.Tasks;
using HardwareReservationAndAccountingSystem.ViewsModels.EquipmentBundles;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class EquipmentBundlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentBundlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bundles = _context.EquipmentBundles.ToList();
            return View(bundles);
        }

        public IActionResult Details(int id)
        {
            var bundle = _context.EquipmentBundles
                .Include(m => m.EquipmentsInBundles).ThenInclude(e => e.Equipment)
                .Include(b => b.Notifications)
                .FirstOrDefault(b => b.Id == id);

            if (bundle == null)
            {
                return RedirectToAction("Index");
            }

            var equipmentIds = bundle.EquipmentsInBundles.Select(eb => eb.EquipmentId);

            var availableEquipments = _context.Equipments
                .Where(e => !equipmentIds.Contains(e.Id) && e.Status == EquipmentStatus.Public)
                .ToList();

            var model = new EquipmentBundleDetails
            {
                EquipmentBundle = bundle,
                AvailableEquipments = availableEquipments
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Description, Status")] EquipmentBundle bundle)
        {
            if (ModelState.IsValid)
            {
                var now = DateTime.Now;
                bundle.CreatedOn = now;
                bundle.UpdatedOn = now;

                _context.EquipmentBundles.Add(bundle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = bundle.Id });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id, Title, Description, Status")] EquipmentBundle bundle)
        {
            if (ModelState.IsValid)
            {
                var bundleInDb = _context.EquipmentBundles.Single(x => x.Id == bundle.Id);

                if (bundleInDb == null)
                {
                    return RedirectToAction(nameof(Details), new { id = bundle.Id });
                }

                bundleInDb.Title = bundle.Title;
                bundleInDb.Description = bundle.Description;
                bundleInDb.Status = bundle.Status;

                bundleInDb.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = bundle.Id });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddEquipmentToBundle(EquipmentBundleDetails viewModel)
        {
            var bundle = viewModel.EquipmentBundle;

            var unpreparedEquipmentIds = Request.Form["equipmentListItems"];

            var bundleInDb = _context.EquipmentBundles.Include(b => b.EquipmentsInBundles).ThenInclude(c => c.Equipment).Single(b => b.Id == bundle.Id);

            if (bundleInDb == null)
            {
                return RedirectToAction(nameof(Details), new { id = bundle.Id });
            }

            foreach (var equipmentId in unpreparedEquipmentIds)
            {
                var equipment = _context.Equipments.Single(e => e.Id == Convert.ToInt32(equipmentId));

                if (equipment == null)
                {
                    return RedirectToAction(nameof(Details), new { id = bundle.Id });
                }

                bundleInDb.EquipmentsInBundles.Add(new EquipmentsInBundles { Equipment = equipment, EquipmentBundle = bundleInDb });
            }

            bundleInDb.UpdatedOn = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = bundle.Id });
        }
    }
}