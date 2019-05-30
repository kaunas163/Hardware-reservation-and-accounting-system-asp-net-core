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
    public class EquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipments = _context.Equipments.Include(x => x.EquipmentType).ToList();
            return View(equipments);
        }

        public IActionResult Details(int id)
        {
            var equipment = _context.Equipments
                .Include(x => x.EquipmentType)
                .Include(x => x.Notifications)
                .Include(x => x.EquipmentsInBundles).ThenInclude(b => b.EquipmentBundle)
                .FirstOrDefault(x => x.Id == id);

            if (equipment == null)
            {
                return RedirectToAction("Index");
            }

            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Description, Status, EquipmentType")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                equipment.CreatedOn = DateTime.Now;
                equipment.UpdatedOn = DateTime.Now;
                equipment.Status = EquipmentStatus.Draft;
                equipment.EquipmentType = _context.EquipmentTypes.FirstOrDefault();
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = equipment.Id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}