using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardwareReservationAndAccountingSystem.Data;

namespace HardwareReservationAndAccountingSystem.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.ApplicationUsers.ToList();
            return View(users);
        }

        public IActionResult Details(string id)
        {
            var user = _context.ApplicationUsers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                RedirectToAction("Index");
            }

            return View(user);
        }
    }
}