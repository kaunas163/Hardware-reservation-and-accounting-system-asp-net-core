using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HardwareReservationAndAccountingSystem.Data;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    public class EquipmentTypesController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public EquipmentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var types = _context.EquipmentTypes.ToList();
            return View(types);
        }
    }
}