using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HardwareReservationAndAccountingSystem.Data;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    public class EquipmentsController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public EquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipments = _context.Equipments.ToList();
            return View(equipments);
        }
    }
}