using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Notifications
{
    public class NotificationsIndex
    {
        public List<Notification> Notifications { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<NotificationType> NotificationTypes { get; set; }
    }
}
