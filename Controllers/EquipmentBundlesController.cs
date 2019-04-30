using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HardwareReservationAndAccountingSystem.Data;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    public class EquipmentBundlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentBundlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}