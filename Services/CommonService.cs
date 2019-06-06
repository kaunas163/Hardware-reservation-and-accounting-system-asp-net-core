using HardwareReservationAndAccountingSystem.Data;
using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.Services
{
    public class CommonService
    {
        private readonly ApplicationDbContext _context;

        public CommonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetUnreadNotificationsCount(string userId)
        {
            return _context.Notifications
                .Where(x => x.NotificationsForUsers.Any(u => u.UserId == userId && !u.IsRead))
                .ToList().Count;
        }
    }
}
