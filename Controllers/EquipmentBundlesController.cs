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

            return View(bundle);
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
    }
}