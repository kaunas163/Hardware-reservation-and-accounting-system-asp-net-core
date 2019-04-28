using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HardwareReservationAndAccountingSystem.Data;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    public class EquipmentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        
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