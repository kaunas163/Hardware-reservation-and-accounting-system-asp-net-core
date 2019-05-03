using System;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class NotificationsForUsers
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Display(Name = "Ar perskaitytas?")]
        public bool IsRead { get; set; }

        [Display(Name = "Perskaitymo data")]
        public DateTime? ReadOn { get; set; }

        [Display(Name = "Ar archyvuotas?")]
        public bool IsArchived { get; set; }
    }
}