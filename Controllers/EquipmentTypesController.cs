using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class EquipmentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public EquipmentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // var types = _context.EquipmentTypes.ToList();
            // return View(types);
            return View();
        }
    }
}