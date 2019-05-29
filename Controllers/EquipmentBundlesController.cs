using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;

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
            var bundle = _context.EquipmentBundles.FirstOrDefault(x => x.Id == id);

            if (bundle == null)
            {
                return RedirectToAction("Index");
            }

            return View(bundle);
        }
    }
}