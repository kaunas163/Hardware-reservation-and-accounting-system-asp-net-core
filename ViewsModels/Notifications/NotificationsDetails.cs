using HardwareReservationAndAccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareReservationAndAccountingSystem.ViewsModels.Notifications
{
    public class NotificationsDetails
    {
        public Notification Notification { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public string UserForId { get; set; }

        public List<NotificationType> NotificationTypes { get; set; }
    }
}
