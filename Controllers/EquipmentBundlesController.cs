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
            var availableEquipments = _context.Equipments.Where(e => !equipmentIds.Contains(e.Id)).ToList();

            var model = new EquipmentBundleDetails
            {
                EquipmentBundle = bundle,
                AvailableEquipments = availableEquipments
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Description")] EquipmentBundle bundle)
        {
            if (ModelState.IsValid)
            {
                var now = DateTime.Now;
                bundle.CreatedOn = now;
                bundle.UpdatedOn = now;
                bundle.Status = EquipmentBundleStatus.Draft;
                _context.Add(bundle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = bundle.Id });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddEquipmentToBundle(EquipmentBundle bundle)
        {
            var unpreparedEquipmentIds = Request.Form["equipmentListItems"];

            return Content(unpreparedEquipmentIds);

            //var equipmentIds = unpreparedEquipmentIds.Split(',').Select(x => Convert.ToInt32(x)).ToList();
            //var equipmentBundleInDb = _context.EquipmentBundles.Include("Equipments").Single(x => x.Id == equipmentBundle.Id);

            //if (equipmentBundleInDb == null)
            //{
            //    return HttpNotFound();
            //}

            //foreach (var equipmentId in equipmentIds)
            //{
            //    var equipment = _context.Equipments.Single(x => x.Id == equipmentId);
            //    if (equipment == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    equipmentBundleInDb.Equipments.Add(equipment);
            //}

            //_context.SaveChanges();
            //return RedirectToAction("Details", new { id = equipmentBundle.Id });
        }
    }
}