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
using HardwareReservationAndAccountingSystem.ViewsModels.Equipments;

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
            var model = new EquipmentsIndex
            {
                Equipments = _context.Equipments.Include(x => x.EquipmentType).ToList(),
                EquipmentTypes = _context.EquipmentTypes.Where(t => !t.IsArchived).ToList()
            };

            return View(model);
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
        public async Task<IActionResult> Create(EquipmentNewOrEdit viewModel)
        {
            if (ModelState.IsValid)
            {
                var equipment = viewModel.Equipment;

                var now = DateTime.Now;
                equipment.CreatedOn = now;
                equipment.UpdatedOn = now;

                _context.Equipments.Add(equipment);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = equipment.Id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}